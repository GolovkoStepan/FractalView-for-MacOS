using AppKit;
using FractalViewMac.Model;
using FractalViewMac.Model.Common.Classes;
using FractalViewMac.Model.Fractals;

namespace FractalView
{
    static class MainClass
    {
        internal static MainViewController mainViewController;

        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}
