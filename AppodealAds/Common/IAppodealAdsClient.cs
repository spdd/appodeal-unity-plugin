using AppodealAds.Api;

namespace AppodealAds.Common {
	internal interface IAppodealAdsClient {
		// init sdk
		void initSDK(string appKey);
	}
}
