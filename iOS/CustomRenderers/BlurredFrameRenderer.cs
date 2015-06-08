using System;
using System.Linq;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using TransparentModal.CustomFormElements;
using TransparentModal.iOS.CustomRenderers;

[assembly: ExportRendererAttribute (typeof(BlurredFrame), typeof(BlurredFrameRenderer))]
namespace TransparentModal.iOS.CustomRenderers
{
	public class BlurredFrameRenderer : VisualElementRenderer<BlurredFrame>
    {
        UIVisualEffectView visualEffectView = null;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (visualEffectView != null)
            {
                visualEffectView.Dispose();
            }
        }

		protected override void OnElementChanged(ElementChangedEventArgs<BlurredFrame> e)
        {
            base.OnElementChanged(e);

            BackgroundColor = UIColor.Clear;

            if (visualEffectView != null)
            {
                visualEffectView.Dispose();
                visualEffectView = null;
            }

            if (e.NewElement == null)
            {
                return;
            }

            // Set up a blur effect and use it as the background:
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraLight);
            visualEffectView = new UIVisualEffectView(blurEffect)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };

            InsertSubview(visualEffectView, 0);

            AddConstraint(NSLayoutConstraint.Create(visualEffectView, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1f, 0f));
            AddConstraint(NSLayoutConstraint.Create(visualEffectView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1f, 0f));
            AddConstraint(NSLayoutConstraint.Create(visualEffectView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, 1f, 0f));
            AddConstraint(NSLayoutConstraint.Create(visualEffectView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1f, 0f));
        }

        public override void MovedToSuperview()
        {
            base.MovedToSuperview();


        }
    }
}

