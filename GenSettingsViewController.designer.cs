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
	[Register ("GenSettingsViewController")]
	partial class GenSettingsViewController
	{
		[Outlet]
		AppKit.NSComboBox GenAlgoComboBox { get; set; }

		[Outlet]
		AppKit.NSTextField IterCountLabel { get; set; }

		[Outlet]
		AppKit.NSSlider IterCountSlider { get; set; }

		[Action ("CancelButtonClick:")]
		partial void CancelButtonClick (Foundation.NSObject sender);

		[Action ("OkButtonClick:")]
		partial void OkButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (GenAlgoComboBox != null) {
				GenAlgoComboBox.Dispose ();
				GenAlgoComboBox = null;
			}

			if (IterCountLabel != null) {
				IterCountLabel.Dispose ();
				IterCountLabel = null;
			}

			if (IterCountSlider != null) {
				IterCountSlider.Dispose ();
				IterCountSlider = null;
			}
		}
	}
}
