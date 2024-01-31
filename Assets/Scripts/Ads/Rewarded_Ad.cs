using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Rewarded_Ad : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public int adNumber = 1;

    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    [SerializeField] private GameObject player;
    [SerializeField] private Banner_Ads _bannerAd;

    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        Load_Ad();
    }

    private void Start()
    {
        End_Games_Manager.end_Games_Manager.RegisterRewardedAd(this);
    }

    public void Load_Ad()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void Show_Ad()
    {
        Advertisement.Show(_adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Time.timeScale = 1;
            player.SetActive(true);
            _bannerAd.Load_BannerAd();

            Load_Ad();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        End_Games_Manager.end_Games_Manager.Score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name);
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }
}
