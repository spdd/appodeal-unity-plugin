using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	internal interface IInterstitialAdListener
	{
		void onInterstitialAdLoaded();
		void onInterstitialAdFailedToLoad();
		void onInterstitialAdOpened();
		void onInterstitialAdClosed();
		void onInterstitialAdClicked();
	}
}
