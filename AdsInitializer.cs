using Core.Interfaces;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsInitializer : IUnityAdsInitializationListener, IInitialize
    {
        private readonly string _androidGameId;
        private readonly string _iOSGameId;
        private readonly bool _testMode = true;
        private readonly RewardedAdsButton _rewardedAdsButton;
        private string _gameId;

        public AdsInitializer(string androidGameId, string iOSGameId, bool testMode, RewardedAdsButton rewardedAdsButton)
        {
            _androidGameId = androidGameId;
            _iOSGameId = iOSGameId;
            _testMode = testMode;
            _rewardedAdsButton = rewardedAdsButton;
        }

        public void Initialize()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode, this);
            }
        }


        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            _rewardedAdsButton.LoadAd();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}
