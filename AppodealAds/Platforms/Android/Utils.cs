#if UNITY_ANDROID

using System;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Api;

namespace AppodealAds.Android
{
	internal class Utils
	{
		#region Fully-qualified class names
		
		#region Appodeal Ads SDK class names
		
		public const string AdListenerClassName = "com.appodeal.ads.Appodeal.AdListener";
		public const string AdRequestClassName = "com.appodeal.ads.Appodeal.AODAdRequest";
		
		#endregion
		
		#region Appodeal Ads Unity Plugin class names
		
		public const string BannerViewClassName = "com.appodeal.ads.Appodeal";
		public const string InterstitialClassName = "com.appodeal.ads.Appodeal";
		public const string VideoClassName = "com.appodeal.ads.Appodeal";
		public const string UnityAdBannerListenerClassName = "com.appodeal.ads.BannerCallbacks";
		public const string UnityVideoAdListenerClassName = "com.appodeal.ads.VideoCallbacks";
		public const string UnityInterstitialAdListenerClassName = "com.appodeal.ads.InterstitialCallbacks";

		public static string GetListenerFromType(AdType type) 
		{
			switch (type) 
			{
			case AdType.BANNER:
				return UnityAdBannerListenerClassName;
			case AdType.INTERSTITIAL:
				return UnityInterstitialAdListenerClassName;
			case AdType.VIDEO:
				return UnityVideoAdListenerClassName;
			default:
				return UnityAdBannerListenerClassName;
			}
		}
		
		#endregion
		
		#region Unity class names
		
		public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";
		
		#endregion
		
		#region Android SDK class names
		
		public const string BundleClassName = "android.os.Bundle";
		public const string DateClassName = "java.util.Date";
		
		#endregion
		
		#endregion
		
		#region JavaObject creators

		// pass
		
		#endregion
	}
}

#endif