using System;

using UIKit;
using AppodealAds;

namespace AppodealXamarinDemo
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			bannerTopButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.BannerTop, this);
			
			bannerCenterButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.BannerCenter, this);

			bannerButtomButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.BannerBottom, this);

			interstitialButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.Interstitial, this);

			nonSkippableButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.NonSkippableVideo, this);

			rewardedButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.RewardedVideo, this);

			skippableButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.SkippableVideo, this);

			videoButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.Video, this);

			videoOrInterstitialButton.TouchUpInside += (sender, e) => 
				Appodeal.ShowAd (AppodealShowStyle.VideoOrInterstitial, this);
			
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

