using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Com.Appodeal.Ads;

namespace AppodealXamarinSample
{
	[Activity (Label = "AppodealXamarinSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IInterstitialCallbacks, IBannerCallbacks, Com.Appodeal.Ads.Utils.PermissionsHelper.IAppodealPermissionCallbacks
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
					.SetGender(UserSettings.Gender.MALE)
					.SetRelation(UserSettings.Relation.DATING)
					.SetInterests("reading, games, movies, snowboarding")
					.SetOccupation(UserSettings.Occupation.WORK)
                    .SetUserId("user_id");

				Appodeal.SetTesting(false);
                Appodeal.LogLevel = Com.Appodeal.Ads.Utils.Log.LogLevel.debug;
				Appodeal.SetInterstitialCallbacks(this);
				Appodeal.SetBannerCallbacks(this);
				Appodeal.Confirm(Appodeal.SKIPPABLE_VIDEO);
                Appodeal.RequestAndroidMPermissions(this, this);
                Appodeal.Set728x90Banners(false);
                Appodeal.SetSmartBanners(false);
                Appodeal.SetBannerAnimation(false);
                Appodeal.SetCustomRule("special_user", true);
				Appodeal.Initialize (this, "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f", Appodeal.INTERSTITIAL | Appodeal.BANNER);
				Appodeal.SetBannerViewId(Resource.Id.appodealBannerView);
			};

			Button showInterstitial = FindViewById<Button> (Resource.Id.showI);
			showInterstitial.Click += delegate {
				Appodeal.Show (this, Appodeal.INTERSTITIAL);
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

        public void AccessCoarseLocationResponse(int result)
        {
            bool isGranted = result == (int)Android.Content.PM.Permission.Granted;
            Log.Debug(LOG_TAG, "access location granted: " + isGranted);
        }

        public void WriteExternalStorageResponse(int result)
        {
            bool isGranted = result == (int)Android.Content.PM.Permission.Granted;
            Log.Debug(LOG_TAG, "write external storage granted: " + isGranted);
        }
    }
}


