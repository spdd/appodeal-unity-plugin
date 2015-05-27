using UnityEngine;
using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.iOS
{
	public class IOSAppodealClient : IAppodealAdsClient {

		private IInterstitialAdListener interstitialListener;
		private IBannerAdListener bannerListener;
		private IVideoAdListener videoListener;

		// Init sdk
		public void initSDK(string appKey) {
			Externs.AODUInitAppodeal(appKey);
		}

		public void initSDK(string appKey, int adTypes) {
			Externs.AODUInitAppodeal(appKey);
		}
		
		public static void setInterstitialCallbacks(IInterstitialAdListener listener) 
		{
			this.interstitialListener = listener;
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener)
		{
			this.videoListener = listener;
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener)
		{
			this.bannerListener = listener;
		}
		
		public static void cache(int adTypes)
		{
			// TODO:
		}
		
		public static Boolean isLoaded(int adTypes) 
		{
			// TODO:
			return true;
		}
		
		public static Boolean isPrecache(int adTypes) 
		{
			// TODO:
			return false;
		}
		
		public static Boolean show(int adTypes)
		{
			if (Appodeal.BANNER) {

			} else if (Appodeal.BANNER_BOTTOM) {
				
			} else if (Appodeal.BANNER_TOP) {
				
			} else if (Appodeal.BANNER_CENTER) {
				
			} else if (Appodeal.INTERSTITIAL) {

			} else if (Appodeal.VIDEO) {

			}

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
