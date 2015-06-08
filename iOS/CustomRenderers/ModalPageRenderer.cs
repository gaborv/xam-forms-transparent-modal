using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreFoundation;
using TransparentModal.CustomFormElements;
using TransparentModal.iOS.CustomRenderers;

[assembly: ExportRenderer (typeof(ModalPage), typeof(ModalPageRenderer))]
namespace TransparentModal.iOS.CustomRenderers
{
    public class ModalPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            // UI settings
            this.View.BackgroundColor = UIColor.Clear;
            this.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
            this.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;

            // Close event
            if(e.OldElement as ModalPage != null)
            {
                var hostPage = (ModalPage)e.OldElement;
                hostPage.CloseModalRequested -= OnCloseRequested;
            }

            if (e.NewElement as ModalPage != null)
            {
                var hostPage = (ModalPage)e.NewElement;
                hostPage.CloseModalRequested += OnCloseRequested;
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            SetElementSize (new Size (View.Bounds.Width, View.Bounds.Height));
        }

        static async void OnCloseRequested(object sender, ModalPage.CloseModalRequestedEventArgs e)
        {
            var page = (ModalPage)sender;

            var viewController = PlatformMethods.GetRenderer(page).ViewController;

            if (viewController != null && !viewController.IsBeingDismissed)
            {
                // Hack: http://stackoverflow.com/questions/25762466/trying-to-dismiss-the-presentation-controller-while-transitioning-already
                DispatchQueue.MainQueue.DispatchAfter(DispatchTime.Now, async () => {
                    e.ClosingPageTask = viewController.DismissViewControllerAsync(true);
                    await e.ClosingPageTask;
                    PlatformMethods.DisposeModelAndChildrenRenderers(page);
                });
            }
        }
    }
}

