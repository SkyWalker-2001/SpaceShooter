using UnityEngine;
using UnityEngine.Advertisements;

public class Interstitial_Ads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    [SerializeField] private Banner_Ads _bannerAds;
    string _adUnitId;

    [SerializeField] private int _time_to_skip = 1;
    
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        /*_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;*/


#if UNITY_IOS
            _adUnitId = _iOsAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#elif UNITY_EDITOR
            _adUnitId = _androidAdUnitId;
#endif

        int skip_Number = PlayerPrefs.GetInt("Interstitial", _time_to_skip);
        
        if(skip_Number != 0)
        {
            skip_Number -= 1;
            PlayerPrefs.SetInt("Interstitial", skip_Number);
        }
        else
        {
            LoadAd();
            PlayerPrefs.SetInt("Interstitial", _time_to_skip);
        }

        LoadAd();

    }

    void Start()
    {
        
    }

    public void LoadAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Show Complete {placementId}");
        Time.timeScale = 1;
        _bannerAds.Load_BannerAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Show Faile {placementId}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Show Start {placementId}");
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }

}
