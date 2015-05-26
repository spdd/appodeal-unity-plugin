#if UNITY_ANDROID

using System;
using System.Collections.Generic;

using UnityEngine;

using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.Android
{
	internal class AndroidBannerClient : IAppodealAdsBannerClient
	{
		private AndroidJavaClass bannerView;
		AndroidJavaObject activity;
		AndroidJavaClass playerClass;

		AdType adType = AdType.BANNER;

		public AndroidBannerClient(IAdListener listener)
		{
			playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			bannerView = new AndroidJavaClass(Utils.BannerViewClassName);
			bannerView.CallStatic("setBannerCallbacks", new AdListener(listener, adType));
		}
		
		// Creates a banner view.
		public void CreateBannerView(string appKey, AdPosition position) 
		{
			//
		}
		
		// Load an ad.
		public void LoadAd(AODAdRequest request)
		{
			//bannerView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}

		public bool IsLoaded() 
		{
			return bannerView.CallStatic<bool>("isLoaded", (int)adType);
		}

		// Show the banner view on the screen.
		public void ShowBannerView() 
		{
			bannerView.CallStatic<bool>("show", activity, (int)adType);
		}

		// Hide the banner view from the screen.
		public void HideBannerView()
		{
			bannerView.CallStatic ("hide", activity, (int)adType);
		}

		public void DestroyBannerView() 
		{
		}

		public void Cache()
		{
			bannerView.CallStatic("cache", activity, (int)adType);
		}

		public bool IsPrecache()
		{
			return bannerView.CallStatic<bool>("isPrecache", (int)adType);
		}

		public bool ShowWithPriceFloor()
		{
			return bannerView.CallStatic<bool>("showWithPriceFloor", activity, (int)adType);
		}

		public void SetAutoCache(bool autoCache) {
			bannerView.CallStatic ("setAutoCache", (int)adType, autoCache);
		}

		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
			bannerView.CallStatic("setOnLoadedTriggerBoth", (int)adType, onLoadedTriggerBoth);
		}
	}
}

#endif
