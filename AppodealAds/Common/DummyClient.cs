using UnityEngine;
using AppodealAds.Api;

namespace AppodealAds.Common
{
	internal class DummyClient : IAppodealAdsBannerClient, IAppodealAdsInterstitialClient, IAppodealAdsVideoClient
	{
		public DummyClient(IAdListener listener)
		{
			Debug.Log("Created DummyClient");
		}
		
		public void CreateBannerView(string appKey, AdPosition position)
		{
			Debug.Log("Dummy CreateBannerView");
		}
		
		public void LoadAd()
		{
			Debug.Log("Dummy LoadAd");
		}
		
		public void ShowBannerView()
		{
			Debug.Log("Dummy ShowBannerView");
		}
		
		public void HideBannerView()
		{
			Debug.Log("Dummy HideBannerView");
		}
		
		public void DestroyBannerView()
		{
			Debug.Log("Dummy DestroyBannerView");
		}
		
		public void CreateInterstitialAd(string appKey) {
			Debug.Log("Dummy CreateIntersitialAd");
		}
		
		public bool IsLoaded() {
			Debug.Log("Dummy IsLoaded");
			return true;
		}
		
		public void ShowInterstitial() {
			Debug.Log("Dummy ShowInterstitial");
		}
		
		public void DestroyInterstitial() {
			Debug.Log("Dummy DestroyInterstitial");
		}

		public void CreateVideoAd(string appKey) {
			Debug.Log("Dummy CreateVideoAd");
		}

		public bool IsVideoLoaded() {
			Debug.Log("Dummy IsVideoLoaded");
			return true;
		}

		public void ShowVideoAd() {
			Debug.Log("Dummy ShowVideoAd");
		}
		
		public void DestroyVideoAd() {
			Debug.Log("Dummy DestroyVideoAd");
		}
	}
}
