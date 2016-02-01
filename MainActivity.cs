using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Com.Appodeal.Ads;

namespace AppodealXamarinSample
{
	[Activity (Label = "AppodealXamarinSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IInterstitialCallbacks, IBannerCallbacks, ISkippableVideoCallbacks, IRewardedVideoCallbacks
	{
		
		public String LOG_TAG = "Appodeal";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			Button initialize = FindViewById<Button> (Resource.Id.initialize);
			initialize.Click += delegate {

				Appodeal.GetUserSettings(this)
					.SetAge(25)
					.SetBirthday("17/06/1990")
					.SetAlcohol(UserSettings.Alcohol.NEGATIVE)
					.SetSmoking(UserSettings.Smoking.NEUTRAL)
					.SetEmail("hi@appodeal.com")
					.SetFacebookId("1623169517896758")
					.SetVkId("91918219")
					.SetGender(UserSettings.Gender.MALE)
					.SetRelation(UserSettings.Relation.DATING)
					.SetInterests("reading, games, movies, snowboarding")
					.SetOccupation(UserSettings.Occupation.WORK);

				//Appodeal.TrackInAppPurchase(this, 100, "USD");
				Appodeal.DisableLocationPermissionCheck();
				//Appodeal.DisableNetwork(this, "startapp");
				//Appodeal.DisableNetwork(this, "startapp", Appodeal.BANNER);
				Appodeal.SetAutoCache (Appodeal.INTERSTITIAL, false);
				Appodeal.SetTesting(false);
				Appodeal.SetLogging(true);
				Appodeal.SetInterstitialCallbacks(this);
				Appodeal.SetBannerCallbacks(this);
				Appodeal.SetSkippableVideoCallbacks(this);
				Appodeal.SetRewardedVideoCallbacks(this);
				Appodeal.Confirm(Appodeal.SKIPPABLE_VIDEO);
				Appodeal.Initialize (this, "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f", Appodeal.INTERSTITIAL | Appodeal.SKIPPABLE_VIDEO | Appodeal.BANNER | Appodeal.REWARDED_VIDEO);
			};

			Button cacheInterstitial = FindViewById<Button> (Resource.Id.cacheI);
			cacheInterstitial.Click += delegate {
				Appodeal.Cache(this, Appodeal.INTERSTITIAL);
			};

			Button showInterstitial = FindViewById<Button> (Resource.Id.showI);
			showInterstitial.Click += delegate {
				Appodeal.Show (this, Appodeal.INTERSTITIAL);
			};

			Button showVideo = FindViewById<Button> (Resource.Id.showV);
			showVideo.Click += delegate {
				Appodeal.Show (this, Appodeal.SKIPPABLE_VIDEO);
			};

			Button showRewardedVideo = FindViewById<Button> (Resource.Id.rewarded);
			showRewardedVideo.Click += delegate {
				Appodeal.Show (this, Appodeal.REWARDED_VIDEO);
			};

			Button showBanner = FindViewById<Button> (Resource.Id.showB);
			showBanner.Click += delegate {
				Appodeal.Show (this, Appodeal.BANNER_BOTTOM);
				//Appodeal.SetBannerViewId(Resource.Id.appodealBannerView);
				//Appodeal.Show(this, Appodeal.BANNER_VIEW);
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

		public void OnBannerLoaded() { Log.Debug(LOG_TAG, " OnBannerLoaded"); }
		public void OnBannerFailedToLoad() { Log.Debug(LOG_TAG, " OnBannerFailedToLoad"); }
		public void OnBannerShown() { Log.Debug(LOG_TAG, " OnBannerShown"); }
		public void OnBannerClicked() { Log.Debug(LOG_TAG, " OnBannerClicked"); }

		public void OnSkippableVideoLoaded() { Log.Debug(LOG_TAG, " OnSkippableVideoLoaded"); }
		public void OnSkippableVideoFailedToLoad() { Log.Debug(LOG_TAG, " OnSkippableVideoFailedToLoad"); }
		public void OnSkippableVideoShown() { Log.Debug(LOG_TAG, " OnSkippableVideoShown"); }
		public void OnSkippableVideoClosed() { Log.Debug(LOG_TAG, " OnSkippableVideoClosed"); }
		public void OnSkippableVideoFinished() { Log.Debug(LOG_TAG, " OnSkippableVideoFinished"); }

		public void OnRewardedVideoLoaded() { Log.Debug(LOG_TAG, " OnRewardedVideoLoaded"); }
		public void OnRewardedVideoFailedToLoad() { Log.Debug(LOG_TAG, " OnRewardedVideoFailedToLoad"); }
		public void OnRewardedVideoShown() { Log.Debug(LOG_TAG, " OnRewardedVideoShown"); }
		public void OnRewardedVideoClosed() { Log.Debug(LOG_TAG, " OnRewardedVideoClosed"); }
		public void OnRewardedVideoFinished(int amount, String name) { Log.Debug(LOG_TAG, " OnRewardedVideoFinished " +amount); }

	}
}


