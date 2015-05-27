using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.iOS
{
	internal class IOSBannerClient : IAppodealAdsBannerClient
	{
		#region Banner callback types
		
		internal delegate void AODUAdViewDidReceiveAdCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewDidFailToReceiveAdWithErrorCallback(
			IntPtr bannerClient, string error);
		internal delegate void AODUAdViewWillPresentScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewWillDismissScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewDidDismissScreenCallback(IntPtr bannerClient);
		internal delegate void AODUAdViewWillLeaveApplicationCallback(IntPtr bannerClient);
		
		#endregion
		
		private IAdListener listener;
		private IntPtr bannerViewPtr;
		private static Dictionary<IntPtr, IOSBannerClient> bannerClients;
		
		public IOSBannerClient(IAdListener listener)
		{
			this.listener = listener;
		}
		
		// This property should be used when setting the bannerViewPtr.
		private IntPtr BannerViewPtr
		{
			get
			{
				return bannerViewPtr;
			}
			set
			{
				Externs.AODURelease(bannerViewPtr);
				bannerViewPtr = value;
			}
		}
		
		#region IAppodealAdsBannerClient implementation
		
		// Creates a banner view.
		public void CreateBannerView(string appKey, AdPosition position) {
			IntPtr bannerClientPtr = (IntPtr) GCHandle.Alloc(this);

			BannerViewPtr = Externs.AODUCreateBannerView(
					bannerClientPtr, appKey, (int)position);

			Externs.AODUSetBannerCallbacks(
				BannerViewPtr,
				AdViewDidReceiveAdCallback,
				AdViewDidFailToReceiveAdWithErrorCallback,
				AdViewWillPresentScreenCallback,
				AdViewWillDismissScreenCallback,
				AdViewDidDismissScreenCallback,
				AdViewWillLeaveApplicationCallback);
		}
		
		// Load an ad.
		public void LoadAd(AODAdRequest request)
		{
			IntPtr requestPtr = Externs.AODUCreateRequest();

			Externs.AODURequestBannerAd(BannerViewPtr, requestPtr);
			Externs.AODURelease(requestPtr);
		}

		public bool IsLoaded() 
		{
			return true;
		}
		
		// Show the banner view on the screen.
		public void ShowBannerView() {
			Externs.AODUShowBannerView(BannerViewPtr);
		}
		
		// Hide the banner view from the screen.
		public void HideBannerView()
		{
			Externs.AODUHideBannerView(BannerViewPtr);
		}
		
		public void DestroyBannerView()
		{
			Externs.AODURemoveBannerView(BannerViewPtr);
			BannerViewPtr = IntPtr.Zero;
		}

		public void Cache () 
		{
		}
		
		public bool IsPrecache ()
		{
			return true;
		}
		
		public bool ShowWithPriceFloor ()
		{
			return true;
		}
		
		public void SetAutoCache (bool autoCache)
		{
		}
		
		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
		}
		
		#endregion
		
		#region Banner callback methods
		
		[MonoPInvokeCallback(typeof(AODUAdViewDidReceiveAdCallback))]
		private static void AdViewDidReceiveAdCallback(IntPtr bannerClient)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdLoaded();
		}
		
		[MonoPInvokeCallback(typeof(AODUAdViewDidFailToReceiveAdWithErrorCallback))]
		private static void AdViewDidFailToReceiveAdWithErrorCallback(
			IntPtr bannerClient, string error)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdFailedToLoad(error);
		}
		
		[MonoPInvokeCallback(typeof(AODUAdViewWillPresentScreenCallback))]
		private static void AdViewWillPresentScreenCallback(IntPtr bannerClient)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdOpened();
		}
		
		[MonoPInvokeCallback(typeof(AODUAdViewWillDismissScreenCallback))]
		private static void AdViewWillDismissScreenCallback(IntPtr bannerClient)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdClosing();
		}
		
		[MonoPInvokeCallback(typeof(AODUAdViewDidDismissScreenCallback))]
		private static void AdViewDidDismissScreenCallback(IntPtr bannerClient)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdClosed();
		}
		
		[MonoPInvokeCallback(typeof(AODUAdViewWillLeaveApplicationCallback))]
		private static void AdViewWillLeaveApplicationCallback(IntPtr bannerClient)
		{
			IntPtrToBannerClient(bannerClient).listener.FireAdLeftApplication();
		}
		
		private static IOSBannerClient IntPtrToBannerClient(IntPtr bannerClient)
		{
			GCHandle handle = (GCHandle) bannerClient;
			return handle.Target as IOSBannerClient;
		}
		
		#endregion
	}
}
