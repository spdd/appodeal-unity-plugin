using UnityEngine;
using System;
using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.iOS
{
	public class IOSAppodealClient : IAppodealAdsClient {
		// Init sdk
		public void initSDK(string appKey) {
			Externs.AODUInitAppodeal(appKey);
		}

		public void initSDK(string appKey, AdType type) {
			Externs.AODUInitAppodeal(appKey);
		}
		
		public void disableNetwork(String network) {
		}
		
		public void disableLocationPermissionCheck() {
		}
		
		public void orientationChange() {
		}
	}
}
