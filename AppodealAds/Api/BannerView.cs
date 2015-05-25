using System;
using AppodealAds.Common;

namespace AppodealAds.Api
{
	public class BannerView : IAdListener
	{
		private IAppodealAdsBannerClient client;
		
		// These are the ad callback events that can be hooked into.
		public event EventHandler<EventArgs> AdRewardUser = delegate {};
		public event EventHandler<EventArgs> AdLoaded = delegate {};
		public event EventHandler<AdFailedToLoadEventArgs> AdFailedToLoad = delegate {};
		public event EventHandler<EventArgs> AdOpened = delegate {};
		public event EventHandler<EventArgs> AdClosing = delegate {};
		public event EventHandler<EventArgs> AdClosed = delegate {};
		public event EventHandler<EventArgs> AdLeftApplication = delegate {};
		
		// Create a BannerView and add it into the view hierarchy.
		public BannerView(string appKey, AdPosition position)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsBannerClient(this);
			client.CreateBannerView(appKey, position);
		}
		
		// Load an ad into the BannerView.
		public void LoadAd(AODAdRequest request)
		{
			client.LoadAd(request);
		}
		
		// Hide the BannerView from the screen.
		public void Hide()
		{
			client.HideBannerView();
		}
		
		// Show the BannerView on the screen.
		public void Show()
		{
			client.ShowBannerView();
		}
		
		// Destroy the BannerView.
		public void Destroy()
		{
			client.DestroyBannerView();
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
		
		// The following methods are invoked from an IAppodealAdsClient. Forward these calls
		// to the developer.

		void IAdListener.FireRewardUser(int amount)
		{
			AdRewardUserEventArgs args = new AdRewardUserEventArgs ();
			args.Amount = amount;
			AdRewardUser(this, args);
		}

		void IAdListener.FireAdLoaded()
		{
			AdLoaded(this, EventArgs.Empty);
		}
		
		void IAdListener.FireAdFailedToLoad(string message)
		{
			AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs();
			args.Message = message;
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
		
		#endregion
	}
}
