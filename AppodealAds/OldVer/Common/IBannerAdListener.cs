using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	internal interface IBannerAdListener
	{
		void onAdBannerLoaded();
		void onAdBannerFailedToLoad();
		void onAdBannerOpened();
		void onAdBannerClosed();
		void onAdBannerClicked();
	}
}