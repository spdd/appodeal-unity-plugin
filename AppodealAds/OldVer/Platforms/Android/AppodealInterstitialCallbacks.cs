using UnityEngine;
using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealInterstitialCallbacks
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IInterstitialAdListener listener;	

		public AppodealInterstitialCallbacks(IInterstitialAdListener listener) : base("com.appodeal.ads.InterstitialCallbacks") {
			this.listener = listener;
		}
		
		void onInterstitialLoaded(Boolean isPrecache) {
			//Debug.Log("Appodeal onInterstitialLoaded");
			listener.onInterstitialAdLoaded();
		}
		
		void onInterstitialFailedToLoad() {
			//Debug.Log("Appodeal onInterstitialFailedToLoad");
			listener.onInterstitialAdFailedToLoad();
		}
		
		void onInterstitialShown() {
			//Debug.Log("Appodeal onInterstitialShown");
			listener.onInterstitialAdOpened();
		}
		
		void onInterstitialClicked() {
			//Debug.Log("Appodeal onInterstitialClicked");
			listener.onInterstitialAdClicked();
		}
		
		void onInterstitialClosed() {
			//Debug.Log("Appodeal onInterstitialClosed");
			listener.onInterstitialAdClosed();
		}
	}
#else
	{
		public AppodealInterstitialCallbacks(IInterstitialAdListener listener) { }
	}
#endif
}
