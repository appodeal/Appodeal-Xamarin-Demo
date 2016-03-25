// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppodealXamarinDemo
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton bannerButtomButton { get; set; }

		[Outlet]
		UIKit.UIButton bannerCenterButton { get; set; }

		[Outlet]
		UIKit.UIButton bannerTopButton { get; set; }

		[Outlet]
		UIKit.UIButton interstitialButton { get; set; }

		[Outlet]
		UIKit.UIButton nonSkippableButton { get; set; }

		[Outlet]
		UIKit.UIButton rewardedButton { get; set; }

		[Outlet]
		UIKit.UIButton skippableButton { get; set; }

		[Outlet]
		UIKit.UIButton videoButton { get; set; }

		[Outlet]
		UIKit.UIButton videoOrInterstitialButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bannerTopButton != null) {
				bannerTopButton.Dispose ();
				bannerTopButton = null;
			}

			if (bannerCenterButton != null) {
				bannerCenterButton.Dispose ();
				bannerCenterButton = null;
			}

			if (bannerButtomButton != null) {
				bannerButtomButton.Dispose ();
				bannerButtomButton = null;
			}

			if (interstitialButton != null) {
				interstitialButton.Dispose ();
				interstitialButton = null;
			}

			if (nonSkippableButton != null) {
				nonSkippableButton.Dispose ();
				nonSkippableButton = null;
			}

			if (rewardedButton != null) {
				rewardedButton.Dispose ();
				rewardedButton = null;
			}

			if (skippableButton != null) {
				skippableButton.Dispose ();
				skippableButton = null;
			}

			if (videoButton != null) {
				videoButton.Dispose ();
				videoButton = null;
			}

			if (videoOrInterstitialButton != null) {
				videoOrInterstitialButton.Dispose ();
				videoOrInterstitialButton = null;
			}
		}
	}
}
