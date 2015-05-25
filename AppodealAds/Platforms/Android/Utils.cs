

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
		
		public const string AdListenerClassName = "com.google.android.gms.ads.AdListener";
		public const string AdRequestClassName = "com.google.android.gms.ads.AdRequest";
		public const string AdRequestBuilderClassName =
			"com.google.android.gms.ads.AdRequest$Builder";
		public const string AdSizeClassName = "com.google.android.gms.ads.AdSize";
		public const string AdMobExtrasClassName =
			"com.google.android.gms.ads.mediation.admob.AdMobExtras";
		
		#endregion
		
		#region Appodeal Ads Unity Plugin class names
		
		public const string BannerViewClassName = "com.appodeal.ads.Appodeal";
		public const string InterstitialClassName = "com.appodeal.ads.Appodeal";
		public const string UnityAdListenerClassName = "com.google.unity.ads.UnityAdListener";
		
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

