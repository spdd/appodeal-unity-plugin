using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	internal interface IVideoAdListener
	{
		void onVideoAdRewardUser(int amount);
		void onVideoAdAdLoaded();
		void onVideoAdFailedToLoad();
		void onVideoAdOpened();
		void onVideoAdClosed();
		void onVideoAdClicked();
	}
}
