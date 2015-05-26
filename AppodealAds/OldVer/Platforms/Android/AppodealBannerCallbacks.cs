using UnityEngine;
using System;

namespace AppodealAds.Unity.Android 
{
	public class AppodealBannerCallbacks
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		public AppodealBannerCallbacks() : base("com.appodeal.ads.BannerCallbacks") { }
			
			void onBannerLoaded() {
				//Debug.Log("Appodeal onBannerLoaded");
			}
			
			void onBannerFailedToLoad() {
				//Debug.Log("Appodeal onBannerFailedToLoad");
			}
			
			void onBannerShown() {
				//Debug.Log("Appodeal onBannerShown");
			}
			
			void onBannerClicked() {
				//Debug.Log("Appodeal onBannerClicked");
			}
	}
#else
	{
		public AppodealBannerCallbacks() { }
	}
#endif
}

