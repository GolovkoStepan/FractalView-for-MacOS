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
	[Register ("FractalTypeViewController")]
	partial class FractalTypeViewController
	{
		[Outlet]
		AppKit.NSTextField CenterXLabel { get; set; }

		[Outlet]
		AppKit.NSTextField CenterYLabel { get; set; }

		[Outlet]
		AppKit.NSImageView FractalPresenterImageView { get; set; }

		[Outlet]
		AppKit.NSComboBox FractalTypeComboBox { get; set; }

		[Outlet]
		AppKit.NSTextField SizeAreaLabel { get; set; }

		[Action ("CancelButtonClick:")]
		partial void CancelButtonClick (Foundation.NSObject sender);

		[Action ("OkButtonClick:")]
		partial void OkButtonClick (Foundation.NSObject sender);
		
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

			if (SizeAreaLabel != null) {
				SizeAreaLabel.Dispose ();
				SizeAreaLabel = null;
			}

			if (FractalPresenterImageView != null) {
				FractalPresenterImageView.Dispose ();
				FractalPresenterImageView = null;
			}

			if (FractalTypeComboBox != null) {
				FractalTypeComboBox.Dispose ();
				FractalTypeComboBox = null;
			}
		}
	}
}
