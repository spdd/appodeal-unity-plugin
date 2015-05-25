//
//  AODUVideo.m
//  Unity-iPhone
//
//  Created by Dmitry B on 19.05.15.
//
//

@import CoreGraphics;
@import Foundation;
@import UIKit;

#import <AppodealAds/Appodeal.h>

#import "AODUVideo.h"

#import "UnityAppController.h"

@interface AODUVideo () <AODVideoAdDelegate>
@end

@implementation AODUVideo

+ (UIViewController *)unityGLViewController {
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
}

- (id)initWithVideoClientReference:(AODUTypeVideoClientRef *)videoClient
                                   appKey:(NSString *)appKey {
    self = [super init];
    if (self) {
        _videoClient = videoClient;
    }
    return self;
}

- (void)dealloc {
    //_video.delegate = nil;
}

- (void)loadRequest:(AODAdRequestConfig *)request {
    //[self.video loadRequest:request];
}

- (BOOL)isReady {
    return [Appodeal isVideoAdReady];
}

- (void)show {
    if ([Appodeal isVideoAdReady]) {
        UIViewController *unityController = [AODUVideo unityGLViewController];
        [Appodeal showVideoAd:unityController];
    } else {
        NSLog(@"AppodealAdsPlugin: Video is not ready to be shown.");
    }
}

#pragma mark AODInterstitialDelegate implementation

- (void)onVideoAdDidLoad:(NSString*)adName {
    NSLog(@"video ad from %@ did load", adName);
    if (self.adReceivedCallback) {
        self.adReceivedCallback(self.videoClient);
    }
}

- (void)onVideoAdDidFailToLoad:(NSString*)adName {
    NSLog(@"video ad from %@ failed to load", adName);
    if(self.adFailedCallback) {
        self.adFailedCallback(self.videoClient, [@"error video" cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}

- (void)onVideoAdDidAppear:(NSString*)adName {
    NSLog(@"video ad from %@ shown", adName);
    if (self.willPresentCallback) {
        self.willPresentCallback(self.videoClient);
    }
}

- (void)onVideoAdDidReceiveTapEvent:(NSString*)adName {
    NSLog(@"video ad from %@ has been clicked", adName);
    if (self.willLeaveCallback) {
        self.willLeaveCallback(self.videoClient);
    }
}

- (void)onVideoAdDidDisappear:(NSString*)adName {
    NSLog(@"video ad from %@ has been closed or dismissed", adName);
    if (self.didDismissCallback) {
        self.didDismissCallback(self.videoClient);
    }
}

- (void)onVideoAdShouldRewardUser:(NSString*)adName reward:(int)amount {
    NSLog(@"video ad from %@ has been completed and user rewarded %d virtual currency", adName, amount);
    if (self.rewardUserCallback) {
        self.rewardUserCallback(self.videoClient, amount);
    }
}

@end

