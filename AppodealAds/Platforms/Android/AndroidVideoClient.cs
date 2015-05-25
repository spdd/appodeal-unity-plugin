#if UNITY_ANDROID

using System;
using System.Collections.Generic;

using UnityEngine;

using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.Android
{
	internal class AndroidVideoClient : IAppodealAdsVideoClient
	{
		private AndroidJavaClass video;
		AndroidJavaObject activity;
		AndroidJavaClass playerClass;
		
		AdType adType = AdType.VIDEO;
		
		public AndroidVideoClient(IAdListener listener)
		{
			playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			video = new AndroidJavaClass(Utils.VideoClassName);
			video.CallStatic("setVideoCallbacks", new AdListener(listener, adType));
		}
		
		#region IAppodealAdsVideoClient implementation
		
		public void CreateVideoAd(string appKey) 
		{
			//videol.Call("create", appKey);
		}
		
		public void LoadAd(AODAdRequest request) {
			//video.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}
		
		public bool IsLoaded() 
		{
			return video.Call<bool>("isLoaded", adType);
		}
		
		public void ShowVideoAd() 
		{
			video.CallStatic<bool>("show", activity, adType);
		}
		
		public void DestroyVideoAd() 
		{
		}
		
		public void Cache()
		{
			video.CallStatic("cache", activity, adType);
		}
		
		public bool IsPrecache()
		{
			return video.CallStatic<bool>("isPrecache", adType);
		}
		
		public bool ShowWithPriceFloor()
		{
			return video.CallStatic<bool>("showWithPriceFloor", activity, adType);
		}
		
		public void SetAutoCache(bool autoCache) 
		{
			video.CallStatic ("setAutoCache", adType, autoCache);
		}
		
		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
			video.CallStatic("setOnLoadedTriggerBoth", adType, onLoadedTriggerBoth);
		}

		#endregion
	}
}

#endif
