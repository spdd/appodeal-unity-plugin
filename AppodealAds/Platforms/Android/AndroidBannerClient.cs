

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
			bannerView.CallStatic("setBannerCallbacks", new AdListener(listener));
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
			return bannerView.CallStatic<bool>("isLoaded", adType);
		}

		// Show the banner view on the screen.
		public void ShowBannerView() 
		{
			bannerView.CallStatic<bool>("show", activity, adType);
		}

		// Hide the banner view from the screen.
		public void HideBannerView()
		{
			bannerView.CallStatic ("hide", activity, adType);
		}

		public void DestroyBannerView() 
		{
		}

		public void Cache()
		{
			bannerView.CallStatic("cache", activity, adType);
		}

		public bool IsPrecache()
		{
			return bannerView.CallStatic<bool>("isPrecache", adType);
		}

		public bool ShowWithPriceFloor()
		{
			return bannerView.CallStatic<bool>("showWithPriceFloor", activity, adType);
		}

		public void SetAutoCache(bool autoCache) {
			bannerView.CallStatic ("setAutoCache", adType, autoCache);
		}

		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
			bannerView.CallStatic("setOnLoadedTriggerBoth", adType, onLoadedTriggerBoth);
		}
	}
}


