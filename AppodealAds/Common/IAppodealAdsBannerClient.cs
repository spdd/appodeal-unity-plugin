using AppodealAds.Api;

namespace AppodealAds.Common {
	internal interface IAppodealAdsBannerClient {
		// Create a banner view and add it into the view hierarchy.
		void CreateBannerView(string appKey, AdPosition position);
		
		// Request a new ad for the banner view.
		void LoadAd();
		
		// Show the banner view on the screen.
		void ShowBannerView();
		
		// Hide the banner view from the screen.
		void HideBannerView();
		
		// Destroys a banner view and to free up memory.
		void DestroyBannerView();
	}
}

