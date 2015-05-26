using System;
using UnityEngine;
using AppodealAds.Common;

namespace AppodealAds.Unity
{
	internal class AppodealAdsClientFactory
	{
		internal static IAppodealAdsClient GetAppodealAdsClient()
		{
			#if UNITY_EDITOR
			// Testing UNITY_EDITOR first because the editor also responds to the currently
			// selected platform.
			return null;
			#elif UNITY_ANDROID
			return new AppodealAds.Android.AndroidAppodealClient();
			#elif UNITY_IPHONE
			return new AppodealAds.iOS.IOSAppodealClient();
			#else
			return null;
			#endif
		}

		internal static IAppodealAdsBannerClient GetAppodealAdsBannerClient(
			IAdListener listener)
		{
			#if UNITY_EDITOR
			// Testing UNITY_EDITOR first because the editor also responds to the currently
			// selected platform.
			return new AppodealAds.Common.DummyClient(listener);
			#elif UNITY_ANDROID
			return new AppodealAds.Android.AndroidBannerClient(listener);
			#elif UNITY_IPHONE
			return new AppodealAds.iOS.IOSBannerClient(listener);
			#else
			return new AppodealAds.Common.DummyClient(listener);
			#endif
		}
		
		internal static IAppodealAdsInterstitialClient GetAppodealAdsInterstitialClient(
			IAdListener listener)
		{
			#if UNITY_EDITOR
			// Testing UNITY_EDITOR first because the editor also responds to the currently
			// selected platform.
			return new AppodealAds.Common.DummyClient(listener);
			#elif UNITY_ANDROID
			return new AppodealAds.Android.AndroidInterstitialClient(listener);
			#elif UNITY_IPHONE
			return new AppodealAds.iOS.IOSInterstitialClient(listener);
			#else
			return new AppodealAds.Common.DummyClient(listener);
			#endif
		}

		internal static IAppodealAdsVideoClient GetAppodealAdsVideoClient(
			IAdListener listener)
		{
			#if UNITY_EDITOR
			// Testing UNITY_EDITOR first because the editor also responds to the currently
			// selected platform.
			return new AppodealAds.Common.DummyClient(listener);
			#elif UNITY_ANDROID
			return new AppodealAds.Android.AndroidVideoClient(listener);
			#elif UNITY_IPHONE
			return new AppodealAds.iOS.IOSVideoClient(listener);
			#else
			return new AppodealAds.Common.DummyClient(listener);
			#endif
		}
	}
}