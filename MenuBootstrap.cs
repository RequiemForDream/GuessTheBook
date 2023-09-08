using Ads;
using ChooseModeButtons;
using Factories.MenuScene;
using UI.MenuScene;
using UnityEngine;
using VFX;

namespace Core.MenuScene
{
    public class MenuBootstrap : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private VFXConfig _vfxConfig;
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private ChooseModeButtonConfig _chooseModeButtonConfig;
        [SerializeField] private AdsConfig _adsConfig;

        [Header("UI")]
        [SerializeField] private MenuCanvas _menuCanvas;

        private void Awake()
        {
            CreateFactory(out ChooseModeButtonFactory chooseModeButtonFactory);
            InitializeCanvas(chooseModeButtonFactory);
            InitializeAds();
        }

        private void CreateFactory(out ChooseModeButtonFactory chooseModeButtonFactory)
        {
            ChooseModeButtonFactory newChooseModeFactory = new ChooseModeButtonFactory(_chooseModeButtonConfig);
            chooseModeButtonFactory = newChooseModeFactory;
        }

        private void InitializeCanvas(ChooseModeButtonFactory chooseModeButtonFactory)
        {
            _menuCanvas.Initialize(_vfxConfig, _gameConfig, chooseModeButtonFactory);
        }

        private void InitializeAds()
        {
            RewardedAdsButton rewardedAdsButton = new RewardedAdsButton(_menuCanvas.AdsButton, _adsConfig.AndroidAdUnitId,
                _adsConfig.IOSAdUnitId);
            rewardedAdsButton.Initialize();

            AdsInitializer adsInitializer = new AdsInitializer(_adsConfig.AndroidGameId, _adsConfig.IOSGameId, _adsConfig.TestMode,
                rewardedAdsButton);
            adsInitializer.Initialize();
        }
    }
}