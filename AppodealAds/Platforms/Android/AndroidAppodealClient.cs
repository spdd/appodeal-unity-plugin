#if UNITY_ANDROID

using System;
using System.Collections.Generic;

using UnityEngine;
using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.Android
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

		public void initSDK(string appKey, AdType type) {
			AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
			AndroidJavaObject activity =
				playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass appodealClass = new AndroidJavaClass(Utils.BannerViewClassName);
			appodealClass.CallStatic("initialize", activity, appKey, (int)type);
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

#endif