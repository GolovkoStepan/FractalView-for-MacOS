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
	[Register ("CreateImageViewController")]
	partial class CreateImageViewController
	{
		[Outlet]
		AppKit.NSTextField CenterXLabel { get; set; }

		[Outlet]
		AppKit.NSTextField CenterYLabel { get; set; }

		[Outlet]
		AppKit.NSButton CreateImageButton { get; set; }

		[Outlet]
		AppKit.NSPopUpButton HeightPopUpButton { get; set; }

		[Outlet]
		AppKit.NSStepper IterCountChangeStepper { get; set; }

		[Outlet]
		AppKit.NSTextField IterCountTextField { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator ProgressIndicator { get; set; }

		[Outlet]
		AppKit.NSButton SaveImageButton { get; set; }

		[Outlet]
		AppKit.NSTextField SizeAreaLabel { get; set; }

		[Outlet]
		AppKit.NSTextField StatusLabel { get; set; }

		[Outlet]
		AppKit.NSPopUpButton WidthPopUpButton { get; set; }

		[Action ("StartCalculateButtonClick:")]
		partial void StartCalculateButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CenterXLabel != null) {
				CenterXLabel.Dispose ();
				CenterXLabel = null;
			}

			if (CenterYLabel != null) {
				CenterYLabel.Dispose ();
				CenterYLabel = null;
			}

			if (IterCountChangeStepper != null) {
				IterCountChangeStepper.Dispose ();
				IterCountChangeStepper = null;
			}

			if (IterCountTextField != null) {
				IterCountTextField.Dispose ();
				IterCountTextField = null;
			}

			if (ProgressIndicator != null) {
				ProgressIndicator.Dispose ();
				ProgressIndicator = null;
			}

			if (SaveImageButton != null) {
				SaveImageButton.Dispose ();
				SaveImageButton = null;
			}

			if (CreateImageButton != null) {
				CreateImageButton.Dispose ();
				CreateImageButton = null;
			}

			if (SizeAreaLabel != null) {
				SizeAreaLabel.Dispose ();
				SizeAreaLabel = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (WidthPopUpButton != null) {
				WidthPopUpButton.Dispose ();
				WidthPopUpButton = null;
			}

			if (HeightPopUpButton != null) {
				HeightPopUpButton.Dispose ();
				HeightPopUpButton = null;
			}
		}
	}
}
