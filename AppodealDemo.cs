﻿using System;
using UnityEngine;
using AppodealAds.Api;

// Example script showing how to invoke the Appodeal Ads Unity plugin.
public class AppodealDemo : MonoBehaviour
{
	
	private BannerView bannerView;
	private Appodeal appodeal;
	private InterstitialAd interstitial;
	private VideoAd video;

	void OnGUI()
	{
		// Puts some basic buttons onto the screen.
		GUI.skin.button.fontSize = (int) (0.05f * Screen.height);
		
		Rect requestBannerRect = new Rect(0.1f * Screen.width, 0.05f * Screen.height,
		                                  0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(requestBannerRect, "InitSDK"))
		{
			initAppodeal();
		}
		
		Rect showBannerRect = new Rect(0.1f * Screen.width, 0.175f * Screen.height,
		                               0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showBannerRect, "Show Banner"))
		{
			RequestBanner();
			//bannerView.Show();
		}
		
		Rect showInterstitialRect = new Rect(0.1f * Screen.width, 0.3f * Screen.height,
		                               0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showInterstitialRect, "Show Interstitial"))
		{
			RequestInterstitial();
			ShowInterstitial();
		}
		
		Rect showVideoRect = new Rect(0.1f * Screen.width, 0.425f * Screen.height,
		                                  0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showVideoRect, "Show Video"))
		{
			RequestVideo();
			ShowVideo();
		}

		/*
		Rect requestInterstitialRect = new Rect(0.1f * Screen.width, 0.55f * Screen.height,
		                                        0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(requestInterstitialRect, "Request Interstitial"))
		{
			RequestInterstitial();
		}
		
		Rect showInterstitialRect = new Rect(0.1f * Screen.width, 0.675f * Screen.height,
		                                     0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showInterstitialRect, "Show Interstitial"))
		{
			RequestInterstitial();
			ShowInterstitial();
		}
		
		Rect showVideoRect = new Rect(0.1f * Screen.width, 0.8f * Screen.height,
		                                        0.8f * Screen.width, 0.1f * Screen.height);
		if (GUI.Button(showVideoRect, "Show Video"))
		{
			RequestVideo();
			ShowVideo();
		}
		*/
	}

	private void initAppodeal() {
		#if UNITY_EDITOR
		string appKey = "a23f1c3c5f3a996c6f92ffdb6cb7f52ba14b26e45aab3188";
		#elif UNITY_ANDROID
		string appKey = "cdefd229902583f073a2d7da5fdbb26ef82f5cb72ba0c37b";
		#elif UNITY_IPHONE
		string appKey = "a23f1c3c5f3a996c6f92ffdb6cb7f52ba14b26e45aab3188";
		#else
		string appKey = "unexpected_platform";
		#endif

		appodeal = new Appodeal();
		appodeal.initWithAppKey(appKey);
	}
	
	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string appKey = "unused";
		#elif UNITY_ANDROID
		string appKey = "cdefd229902583f073a2d7da5fdbb26ef82f5cb72ba0c37b";
		#elif UNITY_IPHONE
		string appKey = "a23f1c3c5f3a996c6f92ffdb6cb7f52ba14b26e45aab3188";
		#else
		string appKey = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(appKey, AdPosition.TopPortrait);
		// Register for ad events.
		bannerView.AdLoaded += HandleAdLoaded;
		bannerView.AdFailedToLoad += HandleAdFailedToLoad;
		bannerView.AdOpened += HandleAdOpened;
		bannerView.AdClosing += HandleAdClosing;
		bannerView.AdClosed += HandleAdClosed;
		bannerView.AdLeftApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
	}
	
	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string appKey = "unused";
		#elif UNITY_ANDROID
		string appKey = "cdefd229902583f073a2d7da5fdbb26ef82f5cb72ba0c37b";
		#elif UNITY_IPHONE
		string appKey = "a23f1c3c5f3a996c6f92ffdb6cb7f52ba14b26e45aab3188";
		#else
		string appKey = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(appKey);
		// Register for ad events.
		interstitial.AdLoaded += HandleInterstitialLoaded;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitialOpened;
		interstitial.AdClosing += HandleInterstitialClosing;
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());

	}

	private void RequestVideo()
	{
		#if UNITY_EDITOR
		string appKey = "unused";
		#elif UNITY_ANDROID
		string appKey = "cdefd229902583f073a2d7da5fdbb26ef82f5cb72ba0c37b";
		#elif UNITY_IPHONE
		string appKey = "a23f1c3c5f3a996c6f92ffdb6cb7f52ba14b26e45aab3188";
		#else
		string appKey = "unexpected_platform";
		#endif
		
		// Create an video.
		video = new VideoAd(appKey);
		// Register for ad events.
		video.AdLoaded += HandleVideoLoaded;
		video.AdFailedToLoad += HandleVideoFailedToLoad;
		video.AdOpened += HandleVideoOpened;
		video.AdClosing += HandleVideoClosing;
		video.AdClosed += HandleVideoClosed;
		video.AdLeftApplication += HandleVideoLeftApplication;
		video.AdRewardUser += HandleVideoRewardUser;
		// Load an video ad.
		video.LoadAd(createAdRequest());
		
	}
	
	// Returns an ad request with custom ad targeting.
	private AODAdRequest createAdRequest()
	{
		return new AODAdRequest();
		
	}
	
	private void ShowInterstitial()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			print("Interstitial is not ready yet.");
		}
	}


	private void ShowVideo()
	{
		if (video.IsLoaded())
		{
			video.Show();
		}
		else
		{
			print("Video is not ready yet.");
		}
	}
	
	#region Banner callback handlers
	
	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}
	
	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
	
	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}
	
	void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}
	
	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}
	
	#endregion
	
	#region Interstitial callback handlers
	
	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
	}
	
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}
	
	void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}
	
	#endregion

	#region Video callback handlers
	
	public void HandleVideoLoaded(object sender, EventArgs args)
	{
		print("HandleVideoLoaded event received.");
	}
	
	public void HandleVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleVideoFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleVideoOpened(object sender, EventArgs args)
	{
		print("HandleVideoOpened event received");
	}
	
	void HandleVideoClosing(object sender, EventArgs args)
	{
		print("HandleVideoClosing event received");
	}
	
	public void HandleVideoClosed(object sender, EventArgs args)
	{
		print("HandleVideoClosed event received");
	}
	
	public void HandleVideoLeftApplication(object sender, EventArgs args)
	{
		print("HandleVideoLeftApplication event received");
	}

	public void HandleVideoRewardUser(object sender, AdRewardUserEventArgs args)
	{
		print("HandleRewardUser event received, reward: " + args.Amount);
	}
	
	#endregion
}
