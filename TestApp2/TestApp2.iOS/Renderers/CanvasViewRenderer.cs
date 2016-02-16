using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Foundation;
using TestApp2.iOS.Renderers;
using TestApp2.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using TappedEventArgs = TestApp2.Views.TappedEventArgs;

[assembly: ExportRenderer(typeof(CanvasLayout), typeof(CanvasViewRenderer))]
namespace TestApp2.iOS.Renderers
{
    public class CanvasViewRenderer : ViewRenderer<CanvasLayout, UIView>
    {
        private UITapGestureRecognizer _tapGestureRecognizer;
       
        protected override void OnElementChanged(ElementChangedEventArgs<CanvasLayout> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                this.RemoveGestureRecognizer(_tapGestureRecognizer);
            }

            if (e.OldElement == null)
            {

                _tapGestureRecognizer =
                    new UITapGestureRecognizer((gesture) =>
                    {
                        var point = gesture.LocationInView(this.Control);
                        var view = this.Element;

                        if (view.OnTapped != null)
                        {
                            view.OnTapped(this, new TappedEventArgs(new Point(point.X, point.Y)));
                        }
                    })
                    {
                        NumberOfTapsRequired = 1,
                        NumberOfTouchesRequired = 1
                    };

                this.AddGestureRecognizer(_tapGestureRecognizer);
            }
        }

       
    }
}
