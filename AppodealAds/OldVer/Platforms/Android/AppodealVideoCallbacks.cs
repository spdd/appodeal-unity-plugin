using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealVideoCallbacks 
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IVideoAdListener listener;

		public AppodealVideoCallbacks(IVideoAdListener listener) : base("com.appodeal.ads.VideoCallbacks") {
			this.listener = listener;
		}
		
		void onVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
			listener.onVideoAdAdLoaded();
		}
		
		void onVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
			listener.onVideoAdFailedToLoad();
		}
		
		void onVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
			listener.onVideoAdOpened();
		}
		
		void onVideoFinished() {
			//Debug.Log("Appodeal onVideoFinished");
			listener.onVideoAdRewardUser(0);
		}
		
		void onVideoClosed() {
			//Debug.Log("Appodeal onVideoClosed");
			listener.onVideoAdClosed();
		}
	}
#else
	{
		public AppodealVideoCallbacks(IVideoAdListener listener) { }
	}
#endif
}
