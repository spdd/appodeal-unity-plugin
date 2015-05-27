using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api
{
	public class VideoAd : IAdListener
	{
		private IAppodealAdsVideoClient client;
		private IVideoAdListener listener;
		
		// Creates an InsterstitialAd.
		public VideoAd(string appKey)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsVideoClient(this);
			client.CreateVideoAd(appKey);
		}

		// set listener
		public void SetListener(IVideoAdListener listener)
		{
			this.listener = listener;
		}
		
		// Loads a new interstitial request
		public void LoadAd(AODAdRequest request)
		{
			client.LoadAd(request);
		}
		
		// Determines whether the VideoAd has loaded.
		public bool IsLoaded()
		{
			return client.IsLoaded();
		}
		
		// Show the VideoAd.
		public void Show()
		{
			client.ShowVideoAd();
		}
		
		// Destroy the VideoAd.
		public void Destroy()
		{
			client.DestroyVideoAd();
		}
		
		#region IAdListener implementation
		
		// The following methods are invoked from an IAppodealAdsVideoClient. Forward
		// these calls to the developer.
		void IAdListener.FireAdLoaded()
		{
			listener.onVideoAdAdLoaded ();
		}
		
		void IAdListener.FireAdFailedToLoad(string message)
		{
			listener.onVideoAdFailedToLoad ();
		}
		
		void IAdListener.FireAdOpened()
		{
			listener.onVideoAdOpened ();
		}
		
		void IAdListener.FireAdClosing()
		{
			listener.onVideoAdClosed();
		}
		
		void IAdListener.FireAdClosed()
		{
			listener.onVideoAdClosed();
		}
		
		void IAdListener.FireAdLeftApplication()
		{
			listener.onVideoAdClicked();
		}
		
		void IAdListener.FireRewardUser(int amount)
		{
			AdRewardUserEventArgs args = new AdRewardUserEventArgs ();
			args.Amount = amount;
			listener.onVideoAdRewardUser(amount);
		}
		
		#endregion
	}
}
