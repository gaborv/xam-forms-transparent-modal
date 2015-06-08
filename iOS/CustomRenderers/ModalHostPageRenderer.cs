using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using System.Reflection;
using CoreFoundation;
using TransparentModal.CustomFormElements;
using TransparentModal.iOS.CustomRenderers;

[assembly: ExportRendererAttribute (typeof(ModalHostPage), typeof(ModalHostPageRenderer))]
namespace TransparentModal.iOS.CustomRenderers
{
    public class ModalHostPageRenderer: PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if(e.OldElement as ModalHostPage != null)
            {
                var hostPage = (ModalHostPage)e.OldElement;
                hostPage.DisplayPageModalRequested -= OnDisplayPageModalRequested;
            }

            if (e.NewElement as ModalHostPage != null)
            {
                var hostPage = (ModalHostPage)e.NewElement;
                hostPage.DisplayPageModalRequested += OnDisplayPageModalRequested;
            }
        }

        void OnDisplayPageModalRequested(object sender, ModalHostPage.DisplayPageModalRequestedEventArgs e)
        {
            e.PageToDisplay.Parent = this.Element;
            IVisualElementRenderer renderer = PlatformMethods.GetRenderer (e.PageToDisplay);
            if (renderer == null) {
                renderer = RendererFactory.GetRenderer (e.PageToDisplay);
                PlatformMethods.SetRenderer (e.PageToDisplay, renderer);
            }

            // HACK: http://stackoverflow.com/questions/25762466/trying-to-dismiss-the-presentation-controller-while-transitioning-already
            // Since the pop is applying the hack, we might need to wait here too...
            DispatchQueue.MainQueue.DispatchAfter(DispatchTime.Now, async () =>
                {
                    e.DisplayingPageTask = this.PresentViewControllerAsync(renderer.ViewController, true);
                });
        }
    }
}

