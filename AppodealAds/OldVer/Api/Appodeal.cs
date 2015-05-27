using UnityEngine;
using System;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api 
{
	public class Appodeal 
	{
		private IAppodealAdsClient client;

		public const int INTERSTITIAL  = 1;
		public const int VIDEO         = 2;
		public const int BANNER        = 4;
		public const int BANNER_BOTTOM = 8;
		public const int BANNER_TOP    = 16;
		public const int BANNER_CENTER = 32;
		public const int ALL           = 127;
		public const int ANY           = 127;
		
		public static void initialize(String appKey)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsClient();
			client.initSDK(appKey);
		}
		
		public static void initialize(String appKey, int adTypes)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsClient();
			client.initSDK(appKey, adTypes);
		}
		
		public static void setInterstitialCallbacks(IInterstitialAdListener listener)
		{
			client.setInterstitialCallbacks (listener);
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener)
		{
			client.setVideoCallbacks (listener);
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener)
		{
			client.setBannerCallbacks (listener);
		}
		
		public static void cache(int adTypes)
		{
			client.cache (adTypes);
		}
		
		public static Boolean isLoaded(int adTypes) 
		{
			client.isLoaded (adTypes);
		}
		
		public static Boolean isPrecache(int adTypes) 
		{
			client.isPrecache (adTypes);
		}
		
		public static Boolean show(int adTypes)
		{
			client.show (adTypes);
		}
		
		public static Boolean showWithPriceFloor(int adTypes)
		{
			client.showWithPriceFloor (adTypes);
		}
		
		public static void hide(int adTypes)
		{
			client.hide (adTypes);
		}
		
		public static void orientationChange()
		{
			client.orientationChange ();
		}
		
		public static void setAutoCache(int adTypes, Boolean autoCache) 
		{
			client.setAutoCache (adTypes, autoCache);
		}
		
		public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) 
		{
			client.setOnLoadedTriggerBoth (adTypes, setOnLoadedTriggerBoth);
		}
		
		public static void disableNetwork(String network) 
		{
			client.disableNetwork (network);
		}
		
		public static void disableLocationPermissionCheck() 
		{
			client.disableLocationPermissionCheck ();
		}		
	}
}
