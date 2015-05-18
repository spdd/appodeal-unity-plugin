using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.iOS
{
	internal class IOSVideoClient : IAppodealAdsVideoClient
	{
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
		
		private IAdListener listener;
		private IntPtr videoPtr;
		private static Dictionary<IntPtr, IOSBannerClient> bannerClients;
		
		// This property should be used when setting the interstitialPtr.
		private IntPtr VideoPtr
		{
			get
			{
				return videoPtr;
			}
			set
			{
				Externs.AODURelease(videoPtr);
				videoPtr = value;
			}
		}
		
		public IOSVideoClient(IAdListener listener)
		{
			this.listener = listener;
		}
		
		#region IAppodealAdsVideoClient implementation
		
		public void CreateVideoAd(string appKey) {
			IntPtr videoClientPtr = (IntPtr) GCHandle.Alloc(this);
			VideoPtr = Externs.AODUCreateVideo(videoClientPtr, appKey);
			Externs.AODUSetVideoCallbacks(
				VideoPtr,
				VideoAdShouldRewardUserCallback,
				VideoDidReceiveAdCallback,
				VideoDidFailToReceiveAdWithErrorCallback,
				VideoWillPresentScreenCallback,
				VideoDidDismissScreenCallback,
				VideoWillLeaveApplicationCallback);
		}
		
		public bool IsVideoLoaded() {
			return Externs.AODUVideoReady(VideoPtr);
		}
		
		public void ShowVideoAd() {
			Externs.AODUShowVideo(VideoPtr);
		}
		
		public void DestroyVideoAd() {
			VideoPtr = IntPtr.Zero;
		}
		
		#endregion
		
		#region Banner callback methods
		
		[MonoPInvokeCallback(typeof(AODUVideoDidReceiveAdCallback))]
		private static void VideoDidReceiveAdCallback(IntPtr interstitialClient)
		{
			IntPtrToVideoClient(interstitialClient).listener.FireAdLoaded();
		}
		
		[MonoPInvokeCallback(typeof(AODUVideoDidFailToReceiveAdWithErrorCallback))]
		private static void VideoDidFailToReceiveAdWithErrorCallback(
			IntPtr videoClient, string error)
		{
			IntPtrToVideoClient(videoClient).listener.FireAdFailedToLoad(error);
		}
		
		[MonoPInvokeCallback(typeof(AODUVideoWillPresentScreenCallback))]
		private static void VideoWillPresentScreenCallback(IntPtr videoClient)
		{
			IntPtrToVideoClient(videoClient).listener.FireAdOpened();
		}
		
		[MonoPInvokeCallback(typeof(AODUVideoDidDismissScreenCallback))]
		private static void VideoDidDismissScreenCallback(IntPtr videoClient)
		{
			IntPtrToVideoClient(videoClient).listener.FireAdClosed();
		}
		
		[MonoPInvokeCallback(typeof(AODUVideoWillLeaveApplicationCallback))]
		private static void VideoWillLeaveApplicationCallback(IntPtr videoClient)
		{
			IntPtrToVideoClient(videoClient).listener.FireAdLeftApplication();
		}

		[MonoPInvokeCallback(typeof(AODUVideoAdShouldRewardUserCallback))]
		private static void VideoAdShouldRewardUserCallback(IntPtr videoClient, int amount)
		{
			IntPtrToVideoClient(videoClient).listener.FireRewardUser(amount);
		}
		
		private static IOSVideoClient IntPtrToVideoClient(IntPtr videoClient)
		{
			GCHandle handle = (GCHandle) videoClient;
			return handle.Target as IOSVideoClient;
		}
		
		#endregion
	}
}
