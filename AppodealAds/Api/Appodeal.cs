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

		public void initWithAppKeyAndType(string appKey, AdType type)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsClient();
			client.initSDK(appKey, type);
		}

		public void orientationChange ()
		{
			client.orientationChange();
		}

		public void disableNetwork (String network) 
		{
			client.disableNetwork(network);
		}

		public void disableLocationPermissionCheck() 
		{
			client.disableLocationPermissionCheck ();
		}
	}
}
