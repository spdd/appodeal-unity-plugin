using UnityEngine;
using System.Collections;

namespace AppodealAds.Android 
{
	public class AppodealVideoCallbacks 
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		public AppodealVideoCallbacks() : base("com.appodeal.ads.VideoCallbacks") { }
		
		void onVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
		}
		
		void onVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
		}
		
		void onVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
		}
		
		void onVideoFinished() {
			//Debug.Log("Appodeal onVideoFinished");
		}
		
		void onVideoClosed() {
			//Debug.Log("Appodeal onVideoClosed");
		}
	}
#else
	{
		public AppodealVideoCallbacks() { }
	}
#endif
}
