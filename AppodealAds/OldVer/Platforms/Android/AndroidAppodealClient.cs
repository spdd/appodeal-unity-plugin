
using System;
using System.Collections.Generic;

using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android
{
	public class AndroidAppodealClient : IAppodealAdsClient {

		AndroidJavaClass appodealClass;
		AndroidJavaObject activity;
		AndroidJavaClass playerClass;

		// Init sdk
		public void initSDK(string appKey) {
			AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			AndroidJavaObject activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			appodealClass = new AndroidJavaClass(Utils.BannerViewClassName);
			appodealClass.CallStatic("initialize", activity, appKey);
		}

		public void initSDK(string appKey, int adTypes) {
			AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			AndroidJavaObject activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass appodealClass = new AndroidJavaClass(Utils.BannerViewClassName);
			appodealClass.CallStatic("initialize", activity, appKey, adTypes);
		}


		public static void setInterstitialCallbacks(IInterstitialAdListener listener){
			
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener){
			
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener){
			
		}
		
		public static void cache(int adTypes){
			
		}
		
		public static Boolean isLoaded(int adTypes) {
			
		}
		
		public static Boolean isPrecache(int adTypes) {
			
		}
		
		public static Boolean show(int adTypes){
			
		}
		
		public static Boolean showWithPriceFloor(int adTypes){
			
		}
		
		public static void hide(int adTypes){
			
		}
		
		public static void setAutoCache(int adTypes, Boolean autoCache) {
			
		}
		
		public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) {
			
		}

		public void disableNetwork(String network) {
			appodealClass.CallStatic("disableNetwork", network);
		}
		
		public void disableLocationPermissionCheck() {
			appodealClass.CallStatic("disableLocationPermissionCheck");
		}
		
		public void orientationChange(){
			appodealClass.CallStatic("orientationChange");
		}

	}
}
