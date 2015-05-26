using System;
using AppodealAds.Unity;

namespace AppodealAds.Unity.Common {
	internal interface IAppodealAdsClient {
		// init sdk
		void initSDK(string appKey);
		void initSDK(string appKey, int type);

		void orientationChange ();
		void disableNetwork (String network);
		void disableLocationPermissionCheck();
	}
}
