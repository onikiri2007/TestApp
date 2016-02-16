using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestApp2.Services;

namespace TestApp2.Droid.Services
{
    public class DeviceInfo : IDevice
    {
        public int ScreenWidth
        {
            get { return (int) (Resources.System.DisplayMetrics.WidthPixels/Resources.System.DisplayMetrics.Density); }
      
        }

        public int ScreenHeight
        {
            get { return (int)(Resources.System.DisplayMetrics.HeightPixels / Resources.System.DisplayMetrics.Density); }
    
        }
    }
}