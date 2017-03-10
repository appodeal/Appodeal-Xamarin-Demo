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
	[Activity (Label = "AppodealXamarinSample", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
	public class MainActivity : Activity, IInterstitialCallbacks, IBannerCallbacks, ISkippableVideoCallbacks, IRewardedVideoCallbacks, INativeCallbacks
	{

		private Spinner adType;
		public String LOG_TAG = "Appodeal";
		private Activity mActivity;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			ActionBar.Hide();
			mActivity = this;

			SetContentView (Resource.Layout.Main);

			adType = FindViewById<Spinner>(Resource.Id.adType);
			String[] adTypes = { "Banner", "Banner Top", "Banner Bottom", "Banner View", "Native", "Interstitial", "Skippable Video", "Rewarded Video", "Interstitial or Video" };
			var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.adtypes_array, Android.Resource.Layout.SimpleSpinnerItem);
			adType.Adapter = adapter;

			CheckBox logging = FindViewById<CheckBox>(Resource.Id.logging);
			CheckBox testing = FindViewById<CheckBox>(Resource.Id.testing);
			CheckBox autocache = FindViewById<CheckBox>(Resource.Id.autocache);
			CheckBox confirm = FindViewById<CheckBox>(Resource.Id.confirm);
			CheckBox disableSmartBanners = FindViewById<CheckBox>(Resource.Id.disable_smart_banners);
			CheckBox disableBannerAnimation = FindViewById<CheckBox>(Resource.Id.disable_banner_animation);
			CheckBox disable728x90Banners = FindViewById<CheckBox>(Resource.Id.disable_728x90_banners);
			CheckBox enableTriggerOnLoadedTwice = FindViewById<CheckBox>(Resource.Id.enable_trigger_on_loaded_on_precache);
			CheckBox disableLocationPermissionCheck = FindViewById<CheckBox>(Resource.Id.disable_location_permission_check);
			CheckBox disableWriteExternalStorageCheck = FindViewById<CheckBox>(Resource.Id.disable_write_external_storage_check);

			Button initialize = FindViewById<Button> (Resource.Id.initialize);
			initialize.Click += delegate {

				if(logging.Checked)
					Appodeal.LogLevel = Com.Appodeal.Ads.Utils.Log.LogLevel.Verbose;
				else
					Appodeal.LogLevel = Com.Appodeal.Ads.Utils.Log.LogLevel.None;

				Appodeal.SetTesting(testing.Checked);
				Appodeal.SetAutoCache(GetSelectedAdType(), autocache.Checked);
				Appodeal.SetSmartBanners(!disableSmartBanners.Checked);
				Appodeal.SetBannerAnimation(!disableBannerAnimation.Checked);
				Appodeal.Set728x90Banners(!disable728x90Banners.Checked);
				Appodeal.SetOnLoadedTriggerBoth(GetSelectedAdType(), enableTriggerOnLoadedTwice.Checked);
				if(disableLocationPermissionCheck.Checked) Appodeal.DisableLocationPermissionCheck();
				if(disableWriteExternalStorageCheck.Checked) Appodeal.DisableWriteExternalStoragePermissionCheck();
				
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


				Appodeal.SetAutoCacheNativeIcons(false);
				Appodeal.SetAutoCacheNativeMedia(false);

				Appodeal.SetInterstitialCallbacks(this);
				Appodeal.SetBannerCallbacks(this);
                Appodeal.SetNativeCallbacks(this);

				if(confirm.Checked) Appodeal.Confirm(GetSelectedAdType());
				Appodeal.Initialize (this, "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f", GetSelectedAdType());
				Appodeal.SetBannerViewId(Resource.Id.appodealBannerView);
			};

			Button cache = FindViewById<Button> (Resource.Id.cache);
			cache.Click += delegate {
				Appodeal.Cache(this, GetSelectedAdType());
			};

			Button isLoaded = FindViewById<Button>(Resource.Id.is_loaded);
			isLoaded.Click += delegate {
				Toast.MakeText(this, "is loaded: " + Appodeal.IsLoaded(GetSelectedAdType()), ToastLength.Short).Show();
			};

			Button isPrecache = FindViewById<Button>(Resource.Id.is_precache);
			isPrecache.Click += delegate {
				Toast.MakeText(this, "is precache: " + Appodeal.IsPrecache(GetSelectedAdType()), ToastLength.Short).Show();
			};

			Button show = FindViewById<Button>(Resource.Id.show);
			show.Click += delegate {
				Appodeal.Show(this, GetSelectedAdType());
			};

			Button showWithPlacement = FindViewById<Button> (Resource.Id.show_with_placement);
			showWithPlacement.Click += delegate {
				Appodeal.Show(this, GetSelectedAdType(), "main_menu");
			};

			Button hide = FindViewById<Button> (Resource.Id.hide);
			hide.Click += delegate {
				Appodeal.Hide(this, GetSelectedAdType());
			};
		}

		private int GetSelectedAdType() {
			switch (adType.SelectedItemPosition) {
				case 0:
					return Appodeal.BANNER;
				case 1:
					return Appodeal.BANNER_TOP;
				case 2:
					return Appodeal.BANNER_BOTTOM;
				case 3:
					return Appodeal.BANNER_VIEW;
				case 4:
					return Appodeal.NATIVE;
				case 5:
					return Appodeal.INTERSTITIAL;
				case 6:
					return Appodeal.SKIPPABLE_VIDEO;
				case 7:
					return Appodeal.REWARDED_VIDEO;
				case 8:
					return Appodeal.INTERSTITIAL | Appodeal.SKIPPABLE_VIDEO;
				default:
					return Appodeal.NONE;
			}
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
            NativeAdViewAppWall nativeAdView = FindViewById<NativeAdViewAppWall>(Resource.Id.native_ad_view_app_wall);
            nativeAdView.SetNativeAd(nativeAds[0]);
		}

		public void OnNativeShown(INativeAd nativeAd) { Log.Debug(LOG_TAG, " OnNativeShown"); }
	}
}