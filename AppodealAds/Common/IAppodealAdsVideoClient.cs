using AppodealAds.Api;

namespace AppodealAds.Common {
	internal interface IAppodealAdsVideoClient {
		// Initialization AppodealAds and creates an VideoAd
		void CreateVideoAd(string appKey);

		// Loads a new video request.
		void LoadAd(AODAdRequest request);
		
		// Determines whether the video has loaded.
		bool IsLoaded();
		
		// Shows the Videod.
		void ShowVideoAd();
		
		// Destroys an Video to free up memory.
		void DestroyVideoAd();
	}
}