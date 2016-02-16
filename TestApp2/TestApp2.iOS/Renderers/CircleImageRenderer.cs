using System.ComponentModel;
using System.Diagnostics;
using TestApp2.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
#if __UNIFIED__
using Foundation;
#else
using MonoTouch.Foundation;
#endif

[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]
namespace TestApp2.iOS.Renderers
{

    public class CircleImageRenderer : ImageRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;
            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
              e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
              e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircleImage.FillColorProperty.PropertyName)
            {
                CreateCircle();
            }
        }

      
        private void CreateCircle()
        {
            try
            {
                var size = Math.Min((double) this.Element.Width, (double) this.Element.Height);
                var radius = size/2;
                var layer = this.Control.Layer;

                var view = (CircleImage)this.Element;
                layer.CornerRadius = (float)radius;
                layer.MasksToBounds = false;
                layer.BorderColor = view.BorderColor.ToCGColor();
                layer.BorderWidth = view.BorderThickness;
                layer.BackgroundColor = view.FillColor.ToCGColor();
            
                Control.ClipsToBounds = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }
    }
}
