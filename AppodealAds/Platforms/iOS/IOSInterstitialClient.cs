using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using AppodealAds.Api;
using AppodealAds.Common;

namespace AppodealAds.iOS
{
	internal class IOSInterstitialClient : IAppodealAdsInterstitialClient
	{
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
		
		private IAdListener listener;
		private IntPtr interstitialPtr;
		private static Dictionary<IntPtr, IOSBannerClient> bannerClients;
		
		// This property should be used when setting the interstitialPtr.
		private IntPtr InterstitialPtr
		{
			get
			{
				return interstitialPtr;
			}
			set
			{
				Externs.AODURelease(interstitialPtr);
				interstitialPtr = value;
			}
		}
		
		public IOSInterstitialClient(IAdListener listener)
		{
			this.listener = listener;
		}
		
		#region IAppodealAdsInterstitialClient implementation
		
		public void CreateInterstitialAd(string appKey) {
			IntPtr interstitialClientPtr = (IntPtr) GCHandle.Alloc(this);
			InterstitialPtr = Externs.AODUCreateInterstitial(interstitialClientPtr, appKey);
			Externs.AODUSetInterstitialCallbacks(
				InterstitialPtr,
				InterstitialDidReceiveAdCallback,
				InterstitialDidFailToReceiveAdWithErrorCallback,
				InterstitialWillPresentScreenCallback,
				InterstitialWillDismissScreenCallback,
				InterstitialDidDismissScreenCallback,
				InterstitialWillLeaveApplicationCallback);
		}

		public void LoadAd(AODAdRequest request) {
			IntPtr requestPtr = Externs.AODUCreateRequest();

			Externs.AODURequestInterstitial(InterstitialPtr, requestPtr);
			Externs.AODURelease(requestPtr);
		}
		
		public bool IsLoaded() {
			return Externs.AODUInterstitialReady(InterstitialPtr);
		}
		
		public void ShowInterstitial() {
			Externs.AODUShowInterstitial(InterstitialPtr);
		}
		
		public void DestroyInterstitial() {
			InterstitialPtr = IntPtr.Zero;
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
		
		[MonoPInvokeCallback(typeof(AODUInterstitialDidReceiveAdCallback))]
		private static void InterstitialDidReceiveAdCallback(IntPtr interstitialClient)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdLoaded();
		}
		
		[MonoPInvokeCallback(typeof(AODUInterstitialDidFailToReceiveAdWithErrorCallback))]
		private static void InterstitialDidFailToReceiveAdWithErrorCallback(
			IntPtr interstitialClient, string error)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdFailedToLoad(error);
		}
		
		[MonoPInvokeCallback(typeof(AODUInterstitialWillPresentScreenCallback))]
		private static void InterstitialWillPresentScreenCallback(IntPtr interstitialClient)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdOpened();
		}
		
		[MonoPInvokeCallback(typeof(AODUInterstitialWillDismissScreenCallback))]
		private static void InterstitialWillDismissScreenCallback(IntPtr interstitialClient)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdClosing();
		}
		
		[MonoPInvokeCallback(typeof(AODUInterstitialDidDismissScreenCallback))]
		private static void InterstitialDidDismissScreenCallback(IntPtr interstitialClient)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdClosed();
		}
		
		[MonoPInvokeCallback(typeof(AODUInterstitialWillLeaveApplicationCallback))]
		private static void InterstitialWillLeaveApplicationCallback(IntPtr interstitialClient)
		{
			IntPtrToInterstitialClient(interstitialClient).listener.FireAdLeftApplication();
		}
		
		private static IOSInterstitialClient IntPtrToInterstitialClient(IntPtr interstitialClient)
		{
			GCHandle handle = (GCHandle) interstitialClient;
			return handle.Target as IOSInterstitialClient;
		}
		
		#endregion
	}
}
