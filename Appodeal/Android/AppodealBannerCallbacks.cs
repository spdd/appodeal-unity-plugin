using UnityEngine;
using System;

public class AppodealBannerCallbacks : AndroidJavaProxy
{
    public AppodealBannerCallbacks() : base("com.appodeal.ads.BannerCallbacks") { }
    
    void onBannerLoaded() {
        //Debug.Log("Appodeal onBannerLoaded");
    }
    
    void onBannerFailedToLoad() {
        //Debug.Log("Appodeal onBannerFailedToLoad");
    }
    
    void onBannerShown() {
        //Debug.Log("Appodeal onBannerShown");
    }
    
    void onBannerClicked() {
        //Debug.Log("Appodeal onBannerClicked");
    }
}
