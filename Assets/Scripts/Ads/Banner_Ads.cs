using UnityEngine;
using UnityEngine.Advertisements;

public class Banner_Ads : MonoBehaviour
{
    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;


    void Start()
    {

#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        Load_BannerAd();

    }

    public void Load_BannerAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Banner.SetPosition(_bannerPosition);
            BannerLoadOptions options = new BannerLoadOptions()
            {
                loadCallback = OnBannerLoad,
                errorCallback = OnBannerError
            };

            Advertisement.Banner.Load(_adUnitId, options);
        }
    }

    private void OnBannerError(string message)
    {
        Debug.Log("Banner Error : " + message);
    }

    private void OnBannerLoad()
    {
        Advertisement.Banner.Show(_adUnitId);
    }
    
   
    
}
