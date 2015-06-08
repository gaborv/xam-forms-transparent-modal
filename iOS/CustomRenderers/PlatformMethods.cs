using System;
using System.Linq;
using Xamarin.Forms.Platform.iOS;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TransparentModal.iOS.CustomRenderers
{
    /// <summary>
    /// Try to mimic Xamarin.Forms.Platform.iOS.Platform behavior
    /// Using reflection here to to call internal/private methods.
    /// </summary>
    internal static class PlatformMethods
    {
		public static IVisualElementRenderer GetRenderer(BindableObject bindable)
        {
            var assembly = Assembly.Load("Xamarin.Forms.Platform.iOS");
            var type = assembly.GetType("Xamarin.Forms.Platform.iOS.Platform");

            var method = type.GetMethod("GetRenderer", BindingFlags.Public | BindingFlags.Static);

            return (IVisualElementRenderer)method.Invoke(null, new Object[] { bindable });
        }

        public static void SetRenderer(BindableObject bindable, IVisualElementRenderer value)
        {
            var assembly = Assembly.Load("Xamarin.Forms.Platform.iOS");
            var type = assembly.GetType("Xamarin.Forms.Platform.iOS.Platform");

            var method = type.GetMethod("SetRenderer", BindingFlags.Public | BindingFlags.Static);

            method.Invoke(null, new Object[] { bindable, value });
        }

        public static BindableProperty RendererProperty
        {
            get
            {
                var assembly = Assembly.Load("Xamarin.Forms.Platform.iOS");
                var type = assembly.GetType("Xamarin.Forms.Platform.iOS.Platform");

                var property = type.GetRuntimeFields().First(p => p.Name == "RendererProperty");
                return (BindableProperty)property.GetValue(null);
            }
        }
            
        public static void DisposeModelAndChildrenRenderers(Element element)
        {
            // Add custom logic to dispose child elements and renderers or take a look at the similarly named method in
			// Xamarin.Forms.Platform.iOS.Platform
        }
    }
}

