using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobAll : MonoBehaviour
{

    public Text addStatus;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;



    // ID's
    string AppId = "ca-app-pub-2303674815636222~8195163259";
    string BannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    string IntersitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
    string RewardBasedAdUnitId = "ca-app-pub-3940256099942544/5224354917";

    // Start is called before the first frame update
    void Start()
    {
        addStatus.text = "MobileAds.InitializeStart";
        MobileAds.Initialize(initStatus => { });
        addStatus.text = "MobileAds.Initialize";
    }

    #region BannerAdcodeBase 
    public void RequestBanner()
    {
        this.bannerView = new BannerView(BannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
    }

    public void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        addStatus.text = "HandleAdLoaded event received";
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        addStatus.text = "HandleFailedToReceiveAd event received with message: "
                             + args.Message;
    }

    #endregion

    #region InterstitialAdcodeBase 
    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(IntersitialAdUnitId);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnIntersitialAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnIntersitialAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnIntersitialAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnIntersitialAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnIntersitialAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);

    }

    public void ShownIterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }


    public void HandleOnIntersitialAdLoaded(object sender, EventArgs args)
    {
        addStatus.text = ("HandleAdLoaded event received");
    }

    public void HandleOnIntersitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        addStatus.text = ("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnIntersitialAdOpened(object sender, EventArgs args)
    {
        addStatus.text = ("HandleAdOpened event received");
    }

    public void HandleOnIntersitialAdClosed(object sender, EventArgs args)
    {
        addStatus.text = ("HandleAdClosed event received");
    }

    public void HandleOnIntersitialAdLeavingApplication(object sender, EventArgs args)
    {
        addStatus.text = ("HandleAdLeavingApplication event received");
    }
    #endregion

    #region RewardBasedAdcodeBase 
    public void RequestRewardBasedVideo()
    {
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, RewardBasedAdUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        addStatus.text = ("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        addStatus.text = (
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        addStatus.text = ("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        addStatus.text = ("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        addStatus.text = ("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        addStatus.text = (
            "HandleRewardBasedVideoRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        addStatus.text = ("HandleRewardBasedVideoLeftApplication event received");
    }

    public void ShowRewardBasedVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }

    #endregion
}
