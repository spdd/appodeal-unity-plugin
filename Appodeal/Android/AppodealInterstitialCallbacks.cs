using UnityEngine;
using System;

public class AppodealInterstitialCallbacks : AndroidJavaProxy
{
    public AppodealInterstitialCallbacks() : base("com.appodeal.ads.InterstitialCallbacks") { }
    
    void onInterstitialLoaded(Boolean isPrecache) {
        //Debug.Log("Appodeal onInterstitialLoaded");
    }
    
    void onInterstitialFailedToLoad() {
        //Debug.Log("Appodeal onInterstitialFailedToLoad");
    }
    
    void onInterstitialShown() {
        //Debug.Log("Appodeal onInterstitialShown");
    }
    
    void onInterstitialClicked() {
        //Debug.Log("Appodeal onInterstitialClicked");
    }
    
    void onInterstitialClosed() {
        //Debug.Log("Appodeal onInterstitialClosed");
    }
}
