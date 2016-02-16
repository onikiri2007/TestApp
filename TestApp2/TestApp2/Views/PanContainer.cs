using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Services;
using TestApp2.ViewModels;
using Xamarin.Forms;

namespace TestApp2.Views
{
    public class PanContainer : ContentView
    {
        private readonly IDevice _device;
        double x, y;

        public PanContainer(View view, IDevice device)
        {
            _device = device;
            this.WidthRequest = view.WidthRequest;
            this.HeightRequest = view.HeightRequest;

            // Set PanGestureRecognizer.TouchPoints to control the
            // number of touch points needed to pan
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
            this.Content = view;
        }

       
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:

                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    //  Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - _device.ScreenWidth));
                    this.TranslationX = e.TotalX;
                    this.TranslationY = e.TotalY;
                   
                     // Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - _device.ScreenHeight));
                   break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                   
                    //this.Content.Layout(new Rectangle(x, y, this.Width, this.Height));
                    break;
            }
        }
    }
    
}
