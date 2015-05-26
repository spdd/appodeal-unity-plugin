using UnityEngine;
using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.iOS
{
	public class IOSAppodealClient : IAppodealAdsClient {

		#region Banner callback types
		
		internal delegate void AODUAdViewDidReceiveAdCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewDidFailToReceiveAdWithErrorCallback(
			IntPtr bannerClient, string error);
		internal delegate void AODUAdViewWillPresentScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewWillDismissScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewDidDismissScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewWillLeaveApplicationCallback(IntPtr bannerClient);
		
		#endregion

		#region Interstitial callback types

		internal delegate void AODUInterstitialDidReceiveAdCallback(IntPtr interstitialClient);
		internal delegate void AODUInterstitialDidFailToReceiveAdWithErrorCallback(
			IntPtr interstitialClient, string error);
		internal delegate void AODUInterstitialWillPresentScreenCallback(IntPtr interstitialClient);
		internal delegate void AODUInterstitialWillDismissScreenCallback(IntPtr interstitialClient);
		internal delegate void AODUInterstitialDidDismissScreenCallback(IntPtr interstitialClient);
		internal delegate void AODUInterstitialWillLeaveApplicationCallback(
			IntPtr interstitialClient);
		
		#endregion

		#region Video callback types

		internal delegate void AODUVideoAdShouldRewardUserCallback(IntPtr videoClient, int amount);
		internal delegate void AODUVideoDidReceiveAdCallback(IntPtr videoClient);
		internal delegate void AODUVideoDidFailToReceiveAdWithErrorCallback(
			IntPtr videolClient, string error);
		internal delegate void AODUVideoWillPresentScreenCallback(IntPtr videoClient);
		internal delegate void AODUVideoDidDismissScreenCallback(IntPtr videoClient);
		internal delegate void AODUVideoWillLeaveApplicationCallback(
			IntPtr videoClient);
		
		#endregion

		private IInterstitialAdListener interstitialListener;
		private IBannerAdListener bannerListener;
		private IVideoAdListener videoListener;

		// Init sdk
		public void initSDK(string appKey) {
			Externs.AODUInitAppodeal(appKey);
		}

		public void initSDK(string appKey, AdType type) {
			Externs.AODUInitAppodeal(appKey);
		}
		
		public void disableNetwork(String network) {
		}
		
		public void disableLocationPermissionCheck() {
		}
		
		public void orientationChange() {
		}
	}
}
