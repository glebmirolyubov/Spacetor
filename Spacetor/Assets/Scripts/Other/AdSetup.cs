using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdSetup : MonoBehaviour
{
    public string placementBannerId = "GameBanner";
    public string placementVideoId = "GameOverVideo";

    #if UNITY_IOS
    string gameId = "3427062";
    #elif UNITY_ANDROID
    string gameId = "3427063";
    #endif

    bool testMode = false;

    void Start()
    {
        //Monetization.Initialize(gameId, testMode);
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.Hide();
        Advertisement.Banner.Hide(true);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementBannerId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementBannerId);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
        Advertisement.Banner.Hide(true);
    }

    public void ShowCenterBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
    }

    public void ShowVideoAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    private IEnumerator ShowAdWhenReady()
    {
        yield return new WaitForSeconds(0.5f);

        Advertisement.Show();
    }
}
