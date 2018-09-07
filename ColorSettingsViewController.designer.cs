// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FractalView
{
	[Register ("ColorSettingsViewController")]
	partial class ColorSettingsViewController
	{
		[Outlet]
		AppKit.NSComboBox ColorAlgoComboBox { get; set; }

		[Outlet]
		AppKit.NSSlider ColorBMainImageSlider { get; set; }

		[Outlet]
		AppKit.NSSlider ColorGMainImageSlider { get; set; }

		[Outlet]
		AppKit.NSSlider ColorRMainImageSlider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ColorAlgoComboBox != null) {
				ColorAlgoComboBox.Dispose ();
				ColorAlgoComboBox = null;
			}

			if (ColorBMainImageSlider != null) {
				ColorBMainImageSlider.Dispose ();
				ColorBMainImageSlider = null;
			}

			if (ColorGMainImageSlider != null) {
				ColorGMainImageSlider.Dispose ();
				ColorGMainImageSlider = null;
			}

			if (ColorRMainImageSlider != null) {
				ColorRMainImageSlider.Dispose ();
				ColorRMainImageSlider = null;
			}
		}
	}
}
