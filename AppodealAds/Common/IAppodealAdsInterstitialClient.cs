using AppodealAds.Api;

namespace AppodealAds.Common {
	internal interface IAppodealAdsInterstitialClient {
		// Initialization AppodealAds and creates an InterstitialAd
		void CreateInterstitialAd(string appKey);

		// Determines whether the interstitial has loaded.
		bool IsLoaded();
		
		// Shows the InterstitialAd.
		void ShowInterstitial();
		
		// Destroys an InterstitialAd to free up memory.
		void DestroyInterstitial();
	}
}
