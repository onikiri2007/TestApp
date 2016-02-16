using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestApp2.Droid.Renderers;
using TestApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TappedEventArgs = TestApp2.Views.TappedEventArgs;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CanvasLayout), typeof(CanvasViewRenderer))]
namespace TestApp2.Droid.Renderers
{
    public class CanvasViewRenderer : ViewRenderer<CanvasLayout, View> , GestureDetector.IOnGestureListener, GestureDetector.IOnDoubleTapListener
    {
        private GestureDetector _detector;

        protected override void OnElementChanged(ElementChangedEventArgs<CanvasLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                _detector = new GestureDetector(this.Context, this);
                _detector.SetOnDoubleTapListener(this);
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            _detector.OnTouchEvent(e);

            return base.OnTouchEvent(e);
        }

        public bool OnDown(MotionEvent e)
        {
            if (this.Element.OnTapped != null)
            {
                this.Element.OnTapped(this, new TappedEventArgs(new Point(e.GetX() / Resources.DisplayMetrics.Density, e.GetY() / Resources.DisplayMetrics.Density)));
            }

            return true;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            return true;
        }

        public void OnLongPress(MotionEvent e)
        {
           
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {
           
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
           
            return true;
        }

        public bool OnDoubleTap(MotionEvent e)
        {
            return true;
        }

        public bool OnDoubleTapEvent(MotionEvent e)
        {
            return true;
        }

        public bool OnSingleTapConfirmed(MotionEvent e)
        {
            return true;
        }
    }
}