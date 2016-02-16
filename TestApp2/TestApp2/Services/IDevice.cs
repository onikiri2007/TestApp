using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2.Services
{
    public interface IDevice
    {
        int ScreenWidth { get; }
        int ScreenHeight { get; }
    }
}
