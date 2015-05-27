using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api
{
	public class InterstitialAd : IAdListener
	{
		private IAppodealAdsInterstitialClient client;
		private IInterstitialAdListener listener;
		
		// Creates an InsterstitialAd.
		public InterstitialAd(string appKey)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsInterstitialClient(this);
			client.CreateInterstitialAd(appKey);
		}

		// set listener
		public void SetListener(IInterstitialAdListener listener)
		{
			this.listener = listener;
		}
		
		// Loads a new interstitial request
		public void LoadAd(AODAdRequest request)
		{
			client.LoadAd(request);
		}
		
		// Determines whether the InterstitialAd has loaded.
		public bool IsLoaded()
		{
			return client.IsLoaded();
		}
		
		// Show the InterstitialAd.
		public void Show()
		{
			client.ShowInterstitial();
		}
		
		// Destroy the InterstitialAd.
		public void Destroy()
		{
			client.DestroyInterstitial();
		}

		public void Cache () 
		{
			client.Cache ();
		}
		
		public bool IsPrecache ()
		{
			return client.IsPrecache ();
		}
		
		public bool ShowWithPriceFloor ()
		{
			return client.ShowWithPriceFloor ();
		}
		
		public void SetAutoCache (bool autoCache)
		{
			client.SetAutoCache (autoCache);
		}
		
		public void SetOnLoadedTriggerBoth(bool onLoadedTriggerBoth) 
		{
			client.SetOnLoadedTriggerBoth (onLoadedTriggerBoth);
		}
		
		#region IAdListener implementation
		
		// The following methods are invoked from an IAppodealAdsInterstitialClient. Forward
		// these calls to the developer.
		void IAdListener.FireAdLoaded()
		{
			listener.onInterstitialAdLoaded ();
		}
		
		void IAdListener.FireAdFailedToLoad(string message)
		{
			AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs() {
				Message = message
			};
			listener.onInterstitialAdFailedToLoad();
		}
		
		void IAdListener.FireAdOpened()
		{
			listener.onInterstitialAdOpened();
		}
		
		void IAdListener.FireAdClosing()
		{
			listener.onInterstitialAdClosed ();
		}
		
		void IAdListener.FireAdClosed()
		{
			listener.onInterstitialAdClosed ();
		}
		
		void IAdListener.FireAdLeftApplication()
		{
			listener.onInterstitialAdClicked ();
		}

		void IAdListener.FireRewardUser(int amount)
		{

		}
		
		#endregion
	}
}
