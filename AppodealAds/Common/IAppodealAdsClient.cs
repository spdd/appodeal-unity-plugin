using System;
using AppodealAds.Api;

namespace AppodealAds.Common {
	internal interface IAppodealAdsClient {
		// init sdk
		void initSDK(string appKey);
		void initSDK(string appKey, AdType type);

		void orientationChange ();
		void disableNetwork (String network);
		void disableLocationPermissionCheck();
	}
}
