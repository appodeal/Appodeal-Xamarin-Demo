using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Com.Appodeal.Ads;
using Com.Appodeal.Ads.Native_ad.Views;
using System.Collections.Generic;

namespace AppodealXamarinSample
{
	[Activity (Label = "AppodealXamarinSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IInterstitialCallbacks, IBannerCallbacks, ISkippableVideoCallbacks, IRewardedVideoCallbacks, INativeCallbacks
	{
		
		public String LOG_TAG = "Appodeal";
		private Activity mActivity;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			mActivity = this;

			SetContentView (Resource.Layout.Main);

			Button initialize = FindViewById<Button> (Resource.Id.initialize);
			initialize.Click += delegate {

				Appodeal.GetUserSettings(this)
					.SetAge(25)
					.SetBirthday("17/06/1990")
					.SetAlcohol(UserSettings.Alcohol.NEGATIVE)
					.SetSmoking(UserSettings.Smoking.NEUTRAL)
					.SetEmail("hi@appodeal.com")
					.SetGender(UserSettings.Gender.MALE)
					.SetRelation(UserSettings.Relation.DATING)
					.SetInterests("reading, games, movies, snowboarding")
					.SetOccupation(UserSettings.Occupation.WORK);

				Appodeal.SetCustomRule("name", 10);
				Appodeal.SetCustomRule("name", 100.5);
				Appodeal.SetCustomRule("name", true);
				Appodeal.SetCustomRule("name", "value");

				Appodeal.SetTesting(false);
				Appodeal.LogLevel = Com.Appodeal.Ads.Utils.Log.LogLevel.Verbose;

				Appodeal.SetAutoCacheNativeIcons(false);
				Appodeal.SetAutoCacheNativeMedia(false);

				Appodeal.SetInterstitialCallbacks(this);
				Appodeal.SetBannerCallbacks(this);
				Appodeal.Confirm(Appodeal.SKIPPABLE_VIDEO);
				Appodeal.Initialize (this, "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f", Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO | Appodeal.NATIVE);
				Appodeal.SetBannerViewId(Resource.Id.appodealBannerView);
			};

			Button showInterstitial = FindViewById<Button> (Resource.Id.showI);
			showInterstitial.Click += delegate {
				Appodeal.Show (this, Appodeal.INTERSTITIAL);
			};

			Button showSkippableVideo = FindViewById<Button>(Resource.Id.showS);
			showSkippableVideo.Click += delegate {
				Appodeal.Show(this, Appodeal.SKIPPABLE_VIDEO);
			};

			Button showRewardedVideo = FindViewById<Button>(Resource.Id.showR);
			showRewardedVideo.Click += delegate {
				Appodeal.Show(this, Appodeal.REWARDED_VIDEO);
			};

			Button showNative = FindViewById<Button>(Resource.Id.showN);
			showNative.Click += delegate {
				Appodeal.Cache(this, Appodeal.NATIVE);
			};

			Button showBanner = FindViewById<Button> (Resource.Id.showB);
			showBanner.Click += delegate {
				Appodeal.Show(this, Appodeal.BANNER_VIEW);
			};

			Button hideBanner = FindViewById<Button> (Resource.Id.hideB);
			hideBanner.Click += delegate {
				Appodeal.Hide(this, Appodeal.BANNER);
			};
		}

		public void OnInterstitialLoaded(bool b) { Log.Debug(LOG_TAG, " OnInterstitialLoaded"); }
		public void OnInterstitialFailedToLoad() { Log.Debug(LOG_TAG, " OnInterstitialFailedToLoad"); }
		public void OnInterstitialShown() { Log.Debug(LOG_TAG, " OnInterstitialShown"); }
		public void OnInterstitialClosed() { Log.Debug(LOG_TAG, " OnInterstitialClosed"); }
		public void OnInterstitialClicked() { Log.Debug(LOG_TAG, " OnInterstitialClicked"); }

		public void OnBannerLoaded(int height, bool isPrecache) { Log.Debug(LOG_TAG, " OnBannerLoaded"); }
		public void OnBannerFailedToLoad() { Log.Debug(LOG_TAG, " OnBannerFailedToLoad"); }
		public void OnBannerShown() { Log.Debug(LOG_TAG, " OnBannerShown"); }
		public void OnBannerClicked() { Log.Debug(LOG_TAG, " OnBannerClicked"); }

		public void OnSkippableVideoLoaded() { Log.Debug(LOG_TAG, " OnSkippableVideoLoaded"); }
		public void OnSkippableVideoFailedToLoad() { Log.Debug(LOG_TAG, " OnSkippableVideoFailedToLoad"); }
		public void OnSkippableVideoShown() { Log.Debug(LOG_TAG, " OnSkippableVideoShown"); }
		public void OnSkippableVideoClosed(bool finished) { Log.Debug(LOG_TAG, " OnSkippableVideoClosed"); }
		public void OnSkippableVideoFinished() { Log.Debug(LOG_TAG, " OnSkippableVideoFinished"); }

		public void OnRewardedVideoLoaded() { Log.Debug(LOG_TAG, " OnRewardedVideoLoaded"); }
		public void OnRewardedVideoFailedToLoad() { Log.Debug(LOG_TAG, " OnRewardedVideoFailedToLoad"); }
		public void OnRewardedVideoShown() { Log.Debug(LOG_TAG, " OnRewardedVideoShown"); }
		public void OnRewardedVideoClosed(bool finished) { Log.Debug(LOG_TAG, " OnRewardedVideoClosed"); }
		public void OnRewardedVideoFinished(int amount, string name) { Log.Debug(LOG_TAG, " OnRewardedVideoFinished"); }

		public void OnNativeClicked(INativeAd nativeAd) { Log.Debug(LOG_TAG, " OnNativeClicked"); }

		public void OnNativeFailedToLoad() { Log.Debug(LOG_TAG, " OnNativeFailedToLoad"); }

		public void OnNativeLoaded(IList<INativeAd> nativeAds) {
			
		}

		public void OnNativeShown(INativeAd nativeAd) { Log.Debug(LOG_TAG, " OnNativeShown"); }
	}
}