using System;
using System.Runtime.InteropServices;

namespace AppodealAds.iOS
{
	// Externs used by the iOS component.
	internal class Externs
	{
		#region Common externs
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateRequest();
		
		[DllImport("__Internal")]
		internal static extern void AODUAddTestDevice(IntPtr request, string deviceId);
		
		[DllImport("__Internal")]
		internal static extern void AODUAddKeyword(IntPtr request, string keyword);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetBirthday(IntPtr request, int year, int month, int day);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetGender(IntPtr request, int genderCode);
		
		[DllImport("__Internal")]
		internal static extern void AODUTagForChildDirectedTreatment(
			IntPtr request, bool childDirectedTreatment);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetExtra(IntPtr request, string key, string value);
		
		[DllImport("__Internal")]
		internal static extern void AODURelease(IntPtr obj);
		
		#endregion
		
		#region Banner externs
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateBannerView(
			IntPtr bannerClient, string appKey, int width, int height, int positionAtTop);
		
		[DllImport("__Internal")]
		internal static extern IntPtr AODUCreateSmartBannerView(
			IntPtr bannerClient, string appKey, int positionAtTop);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetBannerCallbacks(
			IntPtr bannerView,
			IOSBannerClient.AODUAdViewDidReceiveAdCallback adReceivedCallback,
			IOSBannerClient.AODUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
			IOSBannerClient.AODUAdViewWillPresentScreenCallback willPresentCallback,
			IOSBannerClient.AODUAdViewWillDismissScreenCallback willDismissCallback,
			IOSBannerClient.AODUAdViewDidDismissScreenCallback didDismissCallback,
			IOSBannerClient.AODUAdViewWillLeaveApplicationCallback willLeaveCallback);
		
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
			IntPtr interstitialClient, string adUnitId);
		
		[DllImport("__Internal")]
		internal static extern void AODUSetInterstitialCallbacks(
			IntPtr interstitial,
			IOSInterstitialClient.AODUInterstitialDidReceiveAdCallback adReceivedCallback,
			IOSInterstitialClient.AODUInterstitialDidFailToReceiveAdWithErrorCallback
			adFailedCallback,
			IOSInterstitialClient.AODUInterstitialWillPresentScreenCallback willPresentCallback,
			IOSInterstitialClient.AODUInterstitialWillDismissScreenCallback willDismissCallback,
			IOSInterstitialClient.AODUInterstitialDidDismissScreenCallback didDismissCallback,
			IOSInterstitialClient.AODUInterstitialWillLeaveApplicationCallback
			willLeaveCallback);
		
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
			IntPtr interstitial,
			IOSVideoClient.AODUVVideoAdShouldRewardUserCallback videoRewardCallback,
			IOSVideoClient.AODUVideoDidReceiveAdCallback videoReceivedCallback,
			IOSVideoClient.AODUVideoDidFailToReceiveAdWithErrorCallback
			videoFailedCallback,
			IOSVideoClient.AODUVideoAdDidAppearCallback videoDidPresentCallback,
			IOSVideoClient.AODUInterstitialDidDismissScreenCallback videoDidDismissCallback,
			IOSVideoClient.AODUInterstitialWillLeaveApplicationCallback
			videoWillLeaveCallback);
		
		[DllImport("__Internal")]
		internal static extern bool AODUVideoReady(IntPtr interstitial);
		
		[DllImport("__Internal")]
		internal static extern void AODUShowVideo(IntPtr interstitial);
		
		[DllImport("__Internal")]
		internal static extern void AODURequestVideol(IntPtr interstitial, IntPtr request);
		
		#endregion
	}
}