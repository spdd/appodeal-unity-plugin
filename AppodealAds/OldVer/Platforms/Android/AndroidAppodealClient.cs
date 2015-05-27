
using System;
using System.Collections.Generic;

using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android
{
	public class AndroidAppodealClient : IAppodealAdsClient 
	{

		AndroidJavaClass appodealClass;
		AndroidJavaObject activity;
		AndroidJavaClass playerClass;

		// Init sdk
		public void initSDK(string appKey) 
		{
			playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			appodealClass = new AndroidJavaClass(Utils.BannerViewClassName);
			appodealClass.CallStatic("initialize", activity, appKey);
		}

		public void initSDK(string appKey, int adTypes) 
		{
			AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			AndroidJavaObject activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass appodealClass = new AndroidJavaClass(Utils.BannerViewClassName);
			appodealClass.CallStatic("initialize", activity, appKey, adTypes);
		}


		public static void setInterstitialCallbacks(IInterstitialAdListener listener) 
		{
			appodealClass.CallStatic("setInterstitialCallbacks", new AppodealInterstitialCallbacks(listener));
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener)
		{
			appodealClass.CallStatic("setVideoCallbacks", new AppodealVideoCallbacks(listener));
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener)
		{
			appodealClass.CallStatic("setBannerCallbacks", new AppodealBannerCallbacks(listener));
		}
		
		public static void cache(int adTypes)
		{
			appodealClass.CallStatic("cache", activity, adTypes);
		}
		
		public static Boolean isLoaded(int adTypes) 
		{
			appodealClass.CallStatic("cache", activity, adTypes);
		}
		
		public static Boolean isPrecache(int adTypes) 
		{
			return appodealClass.CallStatic<Boolean>("isLoaded", adTypes);
		}
		
		public static Boolean show(int adTypes)
		{
			return appodealClass.CallStatic<Boolean>("show", activity, adTypes);
		}
		
		public static Boolean showWithPriceFloor(int adTypes)
		{
			return appodealClass.CallStatic<Boolean>("showWithPriceFloor", activity, adTypes);	
		}
		
		public static void hide(int adTypes)
		{
			appodealClass.CallStatic("hide", activity, adTypes);
		}
		
		public static void setAutoCache(int adTypes, Boolean autoCache) 
		{
			appodealClass.CallStatic("setAutoCache", adTypes, autoCache);	
		}
		
		public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) 
		{
			appodealClass.CallStatic("setOnLoadedTriggerBoth", adTypes, onLoadedTriggerBoth);
		}

		public void disableNetwork(String network) 
		{
			appodealClass.CallStatic("disableNetwork", network);
		}
		
		public void disableLocationPermissionCheck() 
		{
			appodealClass.CallStatic("disableLocationPermissionCheck");
		}
		
		public void orientationChange()
		{
			appodealClass.CallStatic("orientationChange");
		}

	}
}
