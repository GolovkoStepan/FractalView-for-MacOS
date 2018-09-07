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
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		FractalView.NSImageViewCustom MainImageView { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator StasusProgressIndicator { get; set; }

		[Outlet]
		AppKit.NSTextField StatusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MainImageView != null) {
				MainImageView.Dispose ();
				MainImageView = null;
			}

			if (StasusProgressIndicator != null) {
				StasusProgressIndicator.Dispose ();
				StasusProgressIndicator = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}
		}
	}
}
