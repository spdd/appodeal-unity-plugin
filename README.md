AppodealAds Unity Plugin
==============================

The AppodealAds Unity Plugin helps provides a way to
serve AppodealAds in a Unity project deployed as native Android or iOS
applications. Plugin features include:

* Mock ad calls when running inside Unity editor
* Support for Banner Ads
* Support for Interstitial Ads
* Support for Video Ads
* Banner ad events listeners
* A sample project to demonstrate plugin integration

The plugin contains a .unitypackage file for those that want to easily import
the plugin, as well as the source code for those that want to iterate on it.

Requirements
------------
* Unity 4.5
* An appKey
* To deploy on iOS:
    * XCode 5.1 or above
    * [Appodeal-iOS-SDK.zip](http://dl.dropbox.com/s/tandgz79v1t971q/Appodeal-iOS-SDK.zip)[check Getting Started](https://github.com/appodeal/appodeal-ios-demo/wiki/Getting-Started)
    * 7.0.0 or higher

Downloads
----------
Please check out our [AppodealAdsPlugin.unitypackage](http://dl.dropbox.com/s/zg1no6xfiv42lw8/AppodealAdsPlugin.unitypackage)

Integrate the Plugin into your Game
-----------------------------------

1. Open your project in the Unity editor.
2. Navigate to **Assets -> Import Package -> Custom Package**.
3. Select the AppodealAdsPlugin.unitypackage file.
4. Import all of the files for the plugins by selecting **Import**. Make sure
to check for any conflicts with files.

Appodeal Ads Unity API
===========================

The remainder of this guide assumes you are now attempting to write your own
code to integrate Appodeal Ads into your game.

Appodeal Ads Initialization 
-----------------
Here is the minimal code needed to initialize Appodeal Ads.
string appKey = "YOUR_APPKEY";
```c#
using AppodealAds.Api;
...
Appodeal appodeal = new Appodeal();
appodeal.initWithAppKey(appKey);
```

Basic Banner Flow
-----------------
Here is the minimal code needed to create a banner.
```c#
using AppodealAds.Api;
...
// Create banner at the top of the screen.
BannerView bannerView = new BannerView("YOUR_APPKEY", AdPosition.TopPortrait);
// Create an empty ad request.
AODAdRequest request = new AODAdRequest();
// Load the banner with the request.
bannerView.LoadAd(request);
```

Basic Interstitial Flow
-----------------------
Here is the minimal banner code to create an interstitial.

```c#
using AppodealAds.Api;
...
// Initialize an InterstitialAd.
InterstitialAd interstitial = new InterstitialAd("YOUR_APPKEY");
// Create an empty ad request.
AODAdRequest request = new AODAdRequest();
// Load the interstitial with the request.
interstitial.LoadAd(request);

Unlike banners, interstitials need to be explicitly shown. At an appropriate
stopping point in your app, check that the interstitail is ready before
showing it:

if (interstitial.IsLoaded()) {
    interstitial.Show();
}
```

Basic Video Flow
-----------------------
Here is the minimal code to create an video ad.

```c#
using AppodealAds.Api;
...
// Initialize an VideoAd.
VideoAd video = new VideoAd("YOUR_APPKEY");
// Create an empty ad request.
AODAdRequest request = new AODAdRequest();
// Load the video with the request.
video.LoadAd(request);

Unlike banners, video need to be explicitly shown. At an appropriate
stopping point in your app, check that the video is ready before
showing it:

if (video.IsLoaded()) {
    video.Show();
}
```


Banner Placement Locations
--------------------------
The following constants list the available ad positions:

```c#
AdPosition.TopPortrait
AdPosition.BottomPortrait
AdPosition.TopLandscape
AdPosition.BottomLandscape
```


Documentation Appodeal iOS SDK
--------------
Check out our [documentation](https://github.com/appodeal/appodeal-ios-demo/wiki) for documentation on using the SDK

Suggesting improvements
------------------------
To file bugs, make feature requests, or to suggest other improvements, please use [github's issue tracker](https://github.com/appodeal/appodeal-unity-plugin/issues).

License
-------

This plugin uses Google Mobile Ads Unity Plugin source code, Copyright (c) 2014 Google Inc. All Rights Reserved., under the Apache 2.0 License

[Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0.html)
