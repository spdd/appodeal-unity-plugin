//
//  AODUInterface.m
//  iosdemo
//
//  Created by Dmitry B on 19.05.15.
//  Copyright (c) 2015 Appodeal. All rights reserved.
//

#import "AODUBanner.h"
#import "AODUInterstitial.h"
#import "AODUTypes.h"
#import "AODUVideo.h"
#import <AppodealAds/Appodeal.h>

/// Returns an NSString copying the characters from |bytes|, a C array of UTF8-encoded bytes.
/// Returns nil if |bytes| is NULL.
static NSString *AODUStringFromUTF8String(const char *bytes) {
    if (bytes) {
        return @(bytes);
    } else {
        return nil;
    }
}

void AODUInitAppodeal(const char *appKey) {
    [Appodeal initWithAppId:AODUStringFromUTF8String(appKey)];
}

/// Creates a AODBannerView with the specified width, height, and position. Returns a reference to
/// the AODUBannerView.
AODUTypeBannerRef AODUCreateBannerView(AODUTypeBannerClientRef *bannerClient, const char *appKey,
                                       AODBannerType adPosition) {
    AODUBanner *banner = [[AODUBanner alloc] initWithBannerClientReference:bannerClient
                                             appKey:AODUStringFromUTF8String(appKey)
                                           adPosition:adPosition];
    return (__bridge AODUTypeBannerRef)banner;
}

/// Creates a full-width AODBannerView in the current orientation. Returns a reference to the
/// AODUBannerView.
AODUTypeBannerRef AODUCreateSmartBannerView(AODUTypeBannerClientRef *bannerClient,
                                            const char *appKey, AODBannerType adPosition) {
    AODUBanner *banner = [[AODUBanner alloc]
                          initWithSmartBannerSizeAndBannerClientReference:bannerClient
                          appKey:AODUStringFromUTF8String(appKey)
                          adPosition:adPosition];
    return (__bridge AODUTypeBannerRef)banner;
}

/// Creates a AODUInterstitial and returns its reference.
AODUTypeInterstitialRef AODUCreateInterstitial(AODUTypeInterstitialClientRef *interstitialClient,
                                         const char *appKey) {
    return nil;
}

/// Creates a AODUInterstitial and returns its reference.
AODUTypeVideoRef AODUCreateVideo(AODUTypeVideoClientRef *videoClient,
                                         const char *appKey) {
    return nil;
}

/// Sets the banner callback methods to be invoked during banner ad events.
void AODUSetBannerCallbacks(AODUTypeBannerRef banner,
                            AODUAdViewDidReceiveAdCallback adReceivedCallback,
                            AODUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
                            AODUAdViewWillPresentScreenCallback willPresentCallback,
                            AODUAdViewWillDismissScreenCallback willDismissCallback,
                            AODUAdViewDidDismissScreenCallback didDismissCallback,
                            AODUAdViewWillLeaveApplicationCallback willLeaveCallback) {
    AODUBanner *internalBanner = (__bridge AODUBanner *)banner;
    internalBanner.adReceivedCallback = adReceivedCallback;
    internalBanner.adFailedCallback = adFailedCallback;
    internalBanner.willPresentCallback = willPresentCallback;
    internalBanner.willDismissCallback = willDismissCallback;
    internalBanner.didDismissCallback = didDismissCallback;
    internalBanner.willLeaveCallback = willLeaveCallback;
}

/// Sets the interstitial callback methods to be invoked during interstitial ad events.
void AODUSetInterstitialCallbacks(
                                  AODUTypeInterstitialRef interstitial, AODUInterstitialDidReceiveAdCallback adReceivedCallback,
                                  AODUInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                  AODUInterstitialWillPresentScreenCallback willPresentCallback,
                                  AODUInterstitialWillDismissScreenCallback willDismissCallback,
                                  AODUInterstitialDidDismissScreenCallback didDismissCallback,
                                  AODUInterstitialWillLeaveApplicationCallback willLeaveCallback) {
    AODUInterstitial *internalInterstitial = (__bridge AODUInterstitial *)interstitial;
    internalInterstitial.adReceivedCallback = adReceivedCallback;
    internalInterstitial.adFailedCallback = adFailedCallback;
    internalInterstitial.willPresentCallback = willPresentCallback;
    internalInterstitial.willDismissCallback = willDismissCallback;
    internalInterstitial.didDismissCallback = didDismissCallback;
    internalInterstitial.willLeaveCallback = willLeaveCallback;
}

/// Sets the video callback methods to be invoked during video ad events.
void AODUSetVideoCallbacks(
                                  AODUTypeVideoRef video, AODUVideoDidReceiveAdCallback adReceivedCallback,
                                  AODUVideoDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                  AODUVideoWillPresentScreenCallback willPresentCallback,
                                  AODUVideoDidDismissScreenCallback didDismissCallback,
                                  AODUVideoWillLeaveApplicationCallback willLeaveCallback,
                                    AODUVideoAdShouldRewardUserCallback rewardUserCallback) {
    AODUVideo *internalVideo = (__bridge AODUVideo *)video;
    internalVideo.adReceivedCallback = adReceivedCallback;
    internalVideo.adFailedCallback = adFailedCallback;
    internalVideo.willPresentCallback = willPresentCallback;
    internalVideo.didDismissCallback = didDismissCallback;
    internalVideo.willLeaveCallback = willLeaveCallback;
    internalVideo.rewardUserCallback = rewardUserCallback;
}


/// Sets the AODBannerView's hidden property to YES.
void AODUHideBannerView(AODUTypeBannerRef banner) {
    AODUBanner *internalBanner = (__bridge AODUBanner *)banner;
    [internalBanner hideBannerView];
}

/// Sets the AODBannerView's hidden property to NO.
void AODUShowBannerView(AODUTypeBannerRef banner) {
    AODUBanner *internalBanner = (__bridge AODUBanner *)banner;
    [internalBanner showBannerView];
}

/// Removes the AODURemoveBannerView from the view hierarchy.
void AODURemoveBannerView(AODUTypeBannerRef banner) {
    AODUBanner *internalBanner = (__bridge AODUBanner *)banner;
    [internalBanner removeBannerView];
}

/// Returns YES if the AODInterstitial is ready to be shown.
BOOL AODUInterstitialReady(AODUTypeInterstitialRef interstitial) {
    AODUInterstitial *internalInterstitial = (__bridge AODUInterstitial *)interstitial;
    return [internalInterstitial isReady];
}

/// Shows the AODInterstitial.
void AODUShowInterstitial(AODUTypeInterstitialRef interstitial) {
    AODUInterstitial *internalInterstitial = (__bridge AODUInterstitial *)interstitial;
    [internalInterstitial show];
}

/// Creates an empty AODRequest and returns its reference.
AODUTypeRequestRef AODUCreateRequest() {
    //AODURequest *request = [[AODURequest alloc] init];
    //AODUObjectCache *cache = [AODUObjectCache sharedInstance];
    //[cache.references setObject:request forKey:[request AODu_referenceKey]];
    return nil;
}


/// Makes a banner ad request.
void AODURequestBannerAd(AODUTypeBannerRef banner, AODUTypeRequestRef request) {
    AODUBanner *internalBanner = (__bridge AODUBanner *)banner;
    [internalBanner loadRequest:nil];
}


/// Makes an interstitial ad request.
void AODURequestInterstitial(AODUTypeInterstitialRef interstitial, AODUTypeRequestRef request) {
    AODUInterstitial *internalInterstitial = (__bridge AODUInterstitial *)interstitial;
    [internalInterstitial loadRequest:nil];
}

/// Shows the AODVideo.
void AODUShowVideo(AODUTypeVideoRef video) {
    AODUVideo *internalVideo = (__bridge AODUVideo *)video;
    [internalVideo show];
}

/// Makes an video ad request.
void AODURequestVideol(AODUTypeVideoRef video, AODUTypeRequestRef request) {
    AODUVideo *internalVideo = (__bridge AODUVideo *)video;
    [internalVideo loadRequest:nil];
}

/// Returns YES if the AODVideo is ready to be shown.
BOOL AODUVideoReady(AODUTypeVideoRef video) {
    AODUVideo *internalVideo = (__bridge AODUVideo *)video;
    return [internalVideo isReady];
}

/// Removes an object from the cache.
void AODURelease(AODUTypeRef ref) {
    if (ref) {

    }
}
