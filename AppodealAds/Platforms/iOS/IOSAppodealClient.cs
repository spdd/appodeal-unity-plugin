using UnityEngine;
using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.iOS
{
	public class IOSAppodealClient : IAppodealAdsClient {
		// Init sdk
		public void initSDK(string appKey) {
			Externs.AODUInitAppodeal(appKey);
		}
	}
}
