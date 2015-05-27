using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api
{
	public class BannerView : IAdListener
	{
		private IAppodealAdsBannerClient client;
		private IBannerAdListener listener;
		
		// Create a BannerView and add it into the view hierarchy.
		public BannerView(string appKey, AdPosition position)
		{
			client = AppodealAdsClientFactory.GetAppodealAdsBannerClient(this);
			client.CreateBannerView(appKey, position);
		}

		// set listener
		public void SetListener(IBannerAdListener listener)
		{
			this.listener = listener;
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

		}

		void IAdListener.FireAdLoaded()
		{
			listener.onAdBannerLoaded ();
		}
		
		void IAdListener.FireAdFailedToLoad(string message)
		{
			listener.onAdBannerFailedToLoad();
		}
		
		void IAdListener.FireAdOpened()
		{
			listener.onAdBannerOpened ();
		}
		
		void IAdListener.FireAdClosing()
		{
			listener.onAdBannerClosed ();
		}
		
		void IAdListener.FireAdClosed()
		{
			listener.onAdBannerClosed ();
		}
		
		void IAdListener.FireAdLeftApplication()
		{
			listener.onAdBannerClicked ();
		}
		
		#endregion
	}
}
