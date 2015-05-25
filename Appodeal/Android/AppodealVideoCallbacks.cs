using UnityEngine;
using System;

public class AppodealVideoCallbacks : AndroidJavaProxy
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
