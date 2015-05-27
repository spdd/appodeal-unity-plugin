using UnityEngine;
using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealBannerCallbacks
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IBannerAdListener listener;	

		public AppodealBannerCallbacks(IBannerAdListener listener) : base("com.appodeal.ads.BannerCallbacks") {
			this.listener = listener;
		}

		void onBannerLoaded() {
			//Debug.Log("Appodeal onBannerLoaded");
			listener.onAdBannerLoaded();
		}
			
		void onBannerFailedToLoad() {
			//Debug.Log("Appodeal onBannerFailedToLoad");
			listener.onAdBannerFailedToLoad();
		}
			
		void onBannerShown() {
			//Debug.Log("Appodeal onBannerShown");
			listener.onAdBannerOpened();
		}
			
		void onBannerClicked() {
			//Debug.Log("Appodeal onBannerClicked");
			listener.onAdBannerClicked();
		}
	}
#else
	{
		public AppodealBannerCallbacks(IBannerAdListener listener) { }
	}
#endif
}

