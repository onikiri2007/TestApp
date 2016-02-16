using System;
using System.Collections.Generic;
using System.Text;
using TestApp2.Services;
using UIKit;

namespace TestApp2.iOS.Services
{
    public class DeviceInfo : IDevice
    {
        public int ScreenWidth
        {
            get { return (int) UIScreen.MainScreen.Bounds.Width; }
        }

        public int ScreenHeight { get { return (int) UIScreen.MainScreen.Bounds.Height;  } }
    }
}
