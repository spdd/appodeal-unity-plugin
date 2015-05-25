

using System;
using System.Collections.Generic;

using UnityEngine;

using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.Android
{
	internal class AndroidInterstitialClient : IAppodealAdsInterstitialClient
	{
		private AndroidJavaObject interstitial;
		
		public AndroidInterstitialClient(IAdListener listener)
		{
			AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			AndroidJavaObject activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			interstitial = new AndroidJavaObject(
				Utils.InterstitialClassName, activity, new AdListener(listener));
		}
		
		#region IAppodealAdsInterstitialClient implementation
		
		public void CreateInterstitialAd(string adUnitId) {
			interstitial.Call("create", adUnitId);
		}
		
		public void LoadAd(AODAdRequest request) {
			interstitial.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}
		
		public bool IsLoaded() {
			return interstitial.Call<bool>("isLoaded");
		}
		
		public void ShowInterstitial() {
			interstitial.Call("show");
		}
		
		public void DestroyInterstitial() {
			interstitial.Call("destroy");
		}
		
		#endregion
	}
}

