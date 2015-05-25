#if UNITY_ANDROID

using System;
using System.Collections.Generic;

using UnityEngine;

using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.Android
{
	internal class AndroidInterstitialClient : IAppodealAdsInterstitialClient
	{
		private AndroidJavaClass interstitial;
		AndroidJavaObject activity;
		AndroidJavaClass playerClass;

		AdType adType = AdType.INTERSTITIAL;
		
		public AndroidInterstitialClient(IAdListener listener)
		{
			playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			interstitial = new AndroidJavaClass(Utils.InterstitialClassName);
			interstitial.CallStatic("setInterstitialCallbacks", new AdListener(listener, (int)adType));
		}
		
		#region IAppodealAdsInterstitialClient implementation
		
		public void CreateInterstitialAd(string appKey) 
		{
			//interstitial.Call("create", appKey);
		}
		
		public void LoadAd(AODAdRequest request) {
			//interstitial.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}
		
		public bool IsLoaded() 
		{
			return interstitial.Call<bool>("isLoaded", (int)adType);
		}
		
		public void ShowInterstitial() 
		{
			interstitial.CallStatic<bool>("show", activity, (int)adType);
		}
		
		public void DestroyInterstitial() 
		{
		}

		public void Cache()
		{
			interstitial.CallStatic("cache", activity, (int)adType);
		}
		
		public bool IsPrecache()
		{
			return interstitial.CallStatic<bool>("isPrecache", (int)adType);
		}
		
		public bool ShowWithPriceFloor()
		{
			return interstitial.CallStatic<bool>("showWithPriceFloor", activity, (int)adType);
		}
		
		public void SetAutoCache(bool autoCache) 
		{
			interstitial.CallStatic ("setAutoCache", (int)adType, autoCache);
		}
		
		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
			interstitial.CallStatic("setOnLoadedTriggerBoth", (int)adType, onLoadedTriggerBoth);
		}

		
		#endregion
	}
}

#endif