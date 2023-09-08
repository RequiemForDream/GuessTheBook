using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using Core.Interfaces;

namespace Ads
{
    public class RewardedAdsButton : IUnityAdsLoadListener, IUnityAdsShowListener, IInitialize
    {
        private readonly Button _showAdButton;
        private readonly string _androidAdUnitId = "Rewarded_Android";
        private readonly string _iOSAdUnitId = "Rewarded_iOS";
        string _adUnitId = null;

        public RewardedAdsButton(Button showAdButton, string androidAdUnitId, string iOSAdUnitId)
        {
            _showAdButton = showAdButton;
            _androidAdUnitId = androidAdUnitId;
            _iOSAdUnitId = iOSAdUnitId;
        }
        public void Initialize()
        {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
#endif
            _showAdButton.interactable = false;
        }

        public void LoadAd()
        {
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            Debug.Log("Ad Loaded: " + adUnitId);

            if (adUnitId.Equals(_adUnitId))
            {
                _showAdButton.onClick.AddListener(ShowAd);
                _showAdButton.interactable = true;
            }
        }

        public void ShowAd()
        {
            _showAdButton.interactable = false;
            Advertisement.Show(_adUnitId, this);
        }

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                Debug.Log("Unity Ads Rewarded Ad Completed");
            }
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error} - {message}");
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error} - {message}");
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }
    }
}

