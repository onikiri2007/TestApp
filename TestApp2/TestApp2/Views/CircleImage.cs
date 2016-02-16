using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp2.Views
{
    public class CircleImage : Image
    {

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create<CircleImage, int>(p => p.BorderThickness, 0);

        public int BorderThickness
        {
            get { return (int) GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value);}
        }

        public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create<CircleImage, Color>(
            p => p.BorderColor, Color.White);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FillColorProperty =
          BindableProperty.Create<CircleImage, Color>(
            p => p.FillColor, Color.Transparent);

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
    }
}
