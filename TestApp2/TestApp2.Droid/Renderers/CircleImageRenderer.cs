using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestApp2.Views;
using TestApp2.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]
namespace TestApp2.Droid.Renderers
{
    [Preserve(AllMembers = true)]
    public class CircleImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
              e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircleImage.FillColorProperty.PropertyName)
            {
                this.Invalidate();
            }
        }


        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            try
            {

                var radius = Math.Min(Width, Height) / 2;

                var borderThickness = (float)((CircleImage)Element).BorderThickness;

                int strokeWidth = 0;

                if (borderThickness > 0)
                {
                    var logicalDensity = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density;
                    strokeWidth = (int)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2;




                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);


                canvas.Save();
                canvas.ClipPath(path);



                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                paint.Color = ((CircleImage)Element).FillColor.ToAndroid();
                canvas.DrawPath(path, paint);
                paint.Dispose();


                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                path = new Path();
                path.AddCircle((float) Width / 2, (float) Height / 2, radius, Path.Direction.Ccw);


                if (strokeWidth > 0.0f)
                {
                    paint = new Paint {AntiAlias = true, StrokeWidth = strokeWidth};
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((CircleImage)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                }

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}