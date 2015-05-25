using System;
using UnityEngine;

public class Appodeal
{
    public const int INTERSTITIAL  = 1;
    public const int VIDEO         = 2;
    public const int BANNER        = 4;
    public const int BANNER_BOTTOM = 8;
    public const int BANNER_TOP    = 16;
    public const int BANNER_CENTER = 32;
    public const int ALL           = 127;
    public const int ANY           = 127;

    public static void initialize(String appKey){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("initialize", currentActivity, appKey);
            }
        #endif
    }

    public static void initialize(String appKey, int adTypes){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("initialize", currentActivity, appKey, adTypes);
            }
        #endif
    }

    public static void setInterstitialCallbacks(AppodealInterstitialCallbacks callbacks){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("setInterstitialCallbacks", callbacks);
            }
        #endif
    }

    public static void setVideoCallbacks(AppodealVideoCallbacks callbacks){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("setVideoCallbacks", callbacks);
            }
        #endif
    }

    public static void setBannerCallbacks(AppodealBannerCallbacks callbacks){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("setBannerCallbacks", callbacks);
            }
        #endif
    }

    public static void cache(int adTypes){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("cache", currentActivity, adTypes);
            }
        #endif
    }

    public static Boolean isLoaded(int adTypes) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                return jc.CallStatic<Boolean>("isLoaded", adTypes);
            }
        #else
            return false;
        #endif
    }

    public static Boolean isPrecache(int adTypes) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                return jc.CallStatic<Boolean>("isPrecache", adTypes);
            }
        #else
            return false;
        #endif
    }

    public static Boolean show(int adTypes){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                return jc.CallStatic<Boolean>("show", currentActivity, adTypes);
            }
        #else
            return false;
        #endif
    }

    public static Boolean showWithPriceFloor(int adTypes){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                    return jc.CallStatic<Boolean>("showWithPriceFloor", currentActivity, adTypes);
            }
        #else
            return false;
        #endif
    }

    public static void hide(int adTypes){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("hide", currentActivity, adTypes);
            }
        #endif
    }

    public static void orientationChange(){
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("orientationChange");
            }
        #endif
    }

    public static void setAutoCache(int adTypes, Boolean autoCache) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("setAutoCache", adTypes, autoCache);
            }
        #endif
    }

    public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("setOnLoadedTriggerBoth", adTypes, onLoadedTriggerBoth);
            }
        #endif
    }

    public static void disableNetwork(String network) {
        #if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
                jc.CallStatic("disableNetwork", network);
            }
        #endif
    }

	public static void disableLocationPermissionCheck() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		using (AndroidJavaClass jc = new AndroidJavaClass("com.appodeal.ads.Appodeal")) {
			jc.CallStatic("disableLocationPermissionCheck");
		}
		#endif
	}

	public void initWithAppKey(string appKey)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		client = AppodealAdsClientFactory.GetAppodealAdsClient();
		client.initSDK(appKey);
		#endif
	}
}
