using UnityEngine;
using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.iOS
{
	public class IOSAppodealClient : IAppodealAdsClient {

		private IInterstitialAdListener interstitialListener;
		private IBannerAdListener bannerListener;
		private IVideoAdListener videoListener;

		// Init sdk
		public void initSDK(string appKey) {
			Externs.AODUInitAppodeal(appKey);
		}

		public void initSDK(string appKey, int adTypes) {
			Externs.AODUInitAppodeal(appKey);
		}
		
		public static void setInterstitialCallbacks(IInterstitialAdListener listener) 
		{
			this.interstitialListener = listener;
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener)
		{
			this.videoListener = listener;
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener)
		{
			this.bannerListener = listener;
		}
		
		public static void cache(int adTypes)
		{
			// TODO:
		}
		
		public static Boolean isLoaded(int adTypes) 
		{
			// TODO:
			return true;
		}
		
		public static Boolean isPrecache(int adTypes) 
		{
			// TODO:
			return false;
		}
		
		public static Boolean show(int adTypes)
		{
			if (Appodeal.BANNER) {
				BannerView bannerView = new BannerView("", AdPosition.BottomPortrait);
				bannerView.SetListener(bannerListener);
				bannerView.LoadAd(createAdRequest());

			} else if (Appodeal.BANNER_BOTTOM) {
				BannerView bannerView = new BannerView("", AdPosition.BottomPortrait);
				bannerView.SetListener(bannerListener);
				bannerView.LoadAd(createAdRequest());
				
			} else if (Appodeal.BANNER_TOP) {
				BannerView bannerView = new BannerView("", AdPosition.TopPortrait);
				bannerView.SetListener(bannerListener);
				bannerView.LoadAd(createAdRequest());
				
			} else if (Appodeal.BANNER_CENTER) {
				BannerView bannerView = new BannerView("", AdPosition.BottomPortrait);
				bannerView.SetListener(bannerListener);
				bannerView.LoadAd(createAdRequest());
				
			} else if (Appodeal.INTERSTITIAL) {
				InterstitialAd interstitial = new InterstitialAd("");
				interstitial.SetListener(interstitialListener);
				interstitial.LoadAd(createAdRequest());
				if (interstitial.IsLoaded())
				{
					interstitial.Show();
				}
				else
				{
					//print("Interstitial is not ready yet.");
				}
			} else if (Appodeal.VIDEO) {
				VideoAd video = new VideoAd("");
				video.SetListener(videoListener);
				video.LoadAd(createAdRequest());
				if (video.IsLoaded())
				{
					video.Show();
				}
				else
				{
					//print("Video is not ready yet.");
				}
			}

			return true;
		}
		
		public static Boolean showWithPriceFloor(int adTypes)
		{
			return show(adTypes);	
		}
		
		public static void hide(int adTypes)
		{
			// TODO:
		}
		
		public static void setAutoCache(int adTypes, Boolean autoCache) 
		{
			// TODO:	
		}
		
		public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) 
		{
			// TODO:
		}
		
		public void disableNetwork(String network) 
		{
			// TODO:
		}
		
		public void disableLocationPermissionCheck() 
		{
			// TODO:
		}
		
		public void orientationChange()
		{
			// TODO:
		}

		#region private methods

		// Returns an ad request with custom ad targeting.
		private AODAdRequest createAdRequest()
		{
			return new AODAdRequest();
			
		}

		#endregion
	}
}
