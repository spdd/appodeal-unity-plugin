using System;
using AppodealAds.Common;

namespace AppodealAds.Api
{
	public class InterstitialAd : IAdListener
	{
		private IAppodealAdsInterstitialClient client;
		
		// These are the ad callback events that can be hooked into.
		public event EventHandler<EventArgs> AdRewardUser = delegate {};
		public event EventHandler<EventArgs> AdLoaded = delegate {};
		public event EventHandler<AdFailedToLoadEventArgs> AdFailedToLoad = delegate {};
		public event EventHandler<EventArgs> AdOpened = delegate {};
		public event EventHandler<EventArgs> AdClosing = delegate {};
		public event EventHandler<EventArgs> AdClosed = delegate {};
		public event EventHandler<EventArgs> AdLeftApplication = delegate {};
		
		// Creates an InsterstitialAd.
		public InterstitialAd(string appKey)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsInterstitialClient(this);
			client.CreateInterstitialAd(appKey);
		}
		
		// Loads a new interstitial request
		public void LoadAd(AODAdRequest request)
		{
			//client.LoadAd(request);
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
		
		#region IAdListener implementation
		
		// The following methods are invoked from an IAppodealAdsInterstitialClient. Forward
		// these calls to the developer.
		void IAdListener.FireAdLoaded()
		{
			AdLoaded(this, EventArgs.Empty);
		}
		
		void IAdListener.FireAdFailedToLoad(string message)
		{
			AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs() {
				Message = message
			};
			AdFailedToLoad(this, args);
		}
		
		void IAdListener.FireAdOpened()
		{
			AdOpened(this, EventArgs.Empty);
		}
		
		void IAdListener.FireAdClosing()
		{
			AdClosing(this, EventArgs.Empty);
		}
		
		void IAdListener.FireAdClosed()
		{
			AdClosed(this, EventArgs.Empty);
		}
		
		void IAdListener.FireAdLeftApplication()
		{
			AdLeftApplication(this, EventArgs.Empty);
		}

		void IAdListener.FireRewardUser(int amount)
		{
			AdRewardUserEventArgs args = new AdRewardUserEventArgs ();
			args.Amount = amount;
			AdRewardUser(this, args);
		}
		
		#endregion
	}
}
