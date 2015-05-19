using System;
using AppodealAds.Common;

namespace AppodealAds.Api
{
	public class Appodeal
	{
		private IAppodealAdsClient client;

		// Init sdk
		public void initWithAppKey(string appKey)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsClient();
			client.initSDK(appKey);
		}
	}
}
