using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp2.Views
{
    public class TappedEventArgs
    {
        public TappedEventArgs(Point tapped)
        {
            this.TappedLocation = tapped;
        }

        public Point TappedLocation { get; set; }
    }

    public class CanvasLayout : AbsoluteLayout
    {
        public EventHandler<TappedEventArgs> OnTapped;

        
    }
}
