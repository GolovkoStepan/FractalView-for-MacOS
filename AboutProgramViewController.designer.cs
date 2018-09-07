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
	[Register ("AboutProgramViewController")]
	partial class AboutProgramViewController
	{
		[Outlet]
		AppKit.NSImageView ImageView { get; set; }

		[Action ("BackButtonClick:")]
		partial void BackButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}
		}
	}
}
