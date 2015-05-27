using System;
using System.Runtime.InteropServices;

namespace AppodealAds.Unity.iOS
{
	// Externs used by the iOS component.
	internal class Externs
	{
		#region Common externs

		[DllImport("__Internal")]
		internal static extern void AODUInitAppodeal(string appKey);
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateRequest();
		
		[DllImport("__Internal")]
		internal static extern void AODURelease(IntPtr obj);
		
		#endregion
		
		#region Banner externs
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateBannerView(
			IntPtr bannerClient, string appKey, int positionAtTop);
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateSmartBannerView(
			IntPtr bannerClient, string appKey, int positionAtTop);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetBannerCallbacks(
			IntPtr bannerView,
			IOSAppodealClient.AODUAdViewDidReceiveAdCallback adReceivedCallback,
			IOSAppodealClient.AODUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
			IOSAppodealClient.AODUAdViewWillPresentScreenCallback willPresentCallback,
			IOSAppodealClient.AODUAdViewWillDismissScreenCallback willDismissCallback,
			IOSAppodealClient.AODUAdViewDidDismissScreenCallback didDismissCallback,
			IOSAppodealClient.AODUAdViewWillLeaveApplicationCallback willLeaveCallback);
		
		[DllImport("__Internal")]
		internal static extern void AODUHideBannerView(IntPtr bannerView);
		
		[DllImport("__Internal")]
		internal static extern void AODUShowBannerView(IntPtr bannerView);
		
		[DllImport("__Internal")]
		internal static extern void AODURemoveBannerView(IntPtr bannerView);
		
		[DllImport("__Internal")]
		internal static extern void AODURequestBannerAd(IntPtr bannerView, IntPtr request);
		
		#endregion
		
		#region Interstitial externs
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateInterstitial(
			IntPtr interstitialClient, string appKey);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetInterstitialCallbacks(
			IntPtr interstitial,
			IOSAppodealClient.AODUInterstitialDidReceiveAdCallback interstitialReceivedCallback,
			IOSAppodealClient.AODUInterstitialDidFailToReceiveAdWithErrorCallback
			interstitialFailedCallback,
			IOSAppodealClient.AODUInterstitialWillPresentScreenCallback interstitialWillPresentCallback,
			IOSAppodealClient.AODUInterstitialWillDismissScreenCallback interstitialWillDismissCallback,
			IOSAppodealClient.AODUInterstitialDidDismissScreenCallback interstitialDidDismissCallback,
			IOSAppodealClient.AODUInterstitialWillLeaveApplicationCallback
			interstitialWillLeaveCallback);
		
		[DllImport("__Internal")]
		internal static extern bool AODUInterstitialReady(IntPtr interstitial);
		
		[DllImport("__Internal")]
		internal static extern void AODUShowInterstitial(IntPtr interstitial);
		
		[DllImport("__Internal")]
		internal static extern void AODURequestInterstitial(IntPtr interstitial, IntPtr request);
		
		#endregion

		#region Video externs
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateVideo(
			IntPtr videoClient, string appKey);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetVideoCallbacks(
			IntPtr video,
			IOSAppodealClient.AODUVideoAdShouldRewardUserCallback videoRewardCallback,
			IOSAppodealClient.AODUVideoDidReceiveAdCallback videoReceivedCallback,
			IOSAppodealClient.AODUVideoDidFailToReceiveAdWithErrorCallback
			videoFailedCallback,
			IOSAppodealClient.AODUVideoWillPresentScreenCallback videoDidPresentCallback,
			IOSAppodealClient.AODUVideoDidDismissScreenCallback videoDidDismissCallback,
			IOSAppodealClient.AODUVideoWillLeaveApplicationCallback
			videoWillLeaveCallback);
		
		[DllImport("__Internal")]
		internal static extern bool AODUVideoReady(IntPtr video);
		
		[DllImport("__Internal")]
		internal static extern void AODUShowVideo(IntPtr video);
		
		[DllImport("__Internal")]
		internal static extern void AODURequestVideo(IntPtr video, IntPtr request);
		
		#endregion
	}
}