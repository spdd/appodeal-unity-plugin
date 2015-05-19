//
//  AODUInterstitial.m
//  Unity-iPhone
//
//  Created by Dmitry B on 19.05.15.
//
//

@import CoreGraphics;
@import Foundation;
@import UIKit;

#import <AppodealAds/Appodeal.h>

#import "AODUInterstitial.h"

#import "UnityAppController.h"

@interface AODUInterstitial () <AODInterstitialDelegate>
@end

@implementation AODUInterstitial

+ (UIViewController *)unityGLViewController {
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
}

- (id)initWithInterstitialClientReference:(AODUTypeInterstitialClientRef *)interstitialClient
                                 appKey:(NSString *)appKey {
    self = [super init];
    if (self) {
        // init interstitial
    }
    return self;
}

- (void)dealloc {
    //_interstitial.delegate = nil;
}

- (void)loadRequest:(AODAdRequestConfig *)request {
    //[self.interstitial loadRequest:request];
}

- (BOOL)isReady {
    return [Appodeal isInterstitialLoaded];
}

- (void)show {
    if ([Appodeal isInterstitialLoaded]) {
        UIViewController *unityController = [AODUInterstitial unityGLViewController];
        [Appodeal showInterstitial:unityController];
    } else {
        NSLog(@"AppodealAdsPlugin: Interstitial is not ready to be shown.");
    }
}

#pragma mark AODInterstitialDelegate implementation

- (void)onInterstitialAdLoaded:(NSString*)adName isPrecache:(BOOL)isPrecache {
    NSLog(@"interstitial from %@ did load", adName);
    if (self.adReceivedCallback) {
        self.adReceivedCallback(self.interstitialClient);
    }
}

- (void)onInterstitialAdFailedToLoad:(NSString*)adName {
    NSLog(@"interstitial from %@ failed to load", adName);
    self.adFailedCallback(self.interstitialClient, nil);
}

- (void)onInterstitialAdShown:(NSString*)adName {
    NSLog(@"interstitial from %@ shown", adName);
    if (self.willPresentCallback) {
        self.willPresentCallback(self.interstitialClient);
    }
}

- (void)onInterstitialAdClicked:(NSString*)adName {
    NSLog(@"interstitial from %@ has been clicked", adName);
    if (self.willLeaveCallback) {
        self.willLeaveCallback(self.interstitialClient);
    }
}

- (void)onInterstitialAdClosed:(NSString*)adName {
    NSLog(@"interstitial from %@ has been closed or dismissed", adName);
    if (self.didDismissCallback) {
        self.didDismissCallback(self.interstitialClient);
    }
}

@end
