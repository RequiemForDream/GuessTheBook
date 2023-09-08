using Core;
using Factories.MenuScene;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using VFX;

namespace UI.MenuScene
{
    public class MenuCanvas : CanvasModel
    {
        [Header("Buttons")]
        public Button AdsButton;
        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _chooseGameModeBtn;
        [SerializeField] private Button _settingsBtn;

        [Header("Panels")]
        [SerializeField] private ChooseGameModeMenu _chooseGameModeMenu;
        [SerializeField] private SettingsMenu _settingsMenu;

        [Space(5)]
        [SerializeField] private Transform _contentPanel;

        private VFXConfig _vfxConfig;
        private GameConfig _gameConfig;

        public void Initialize(VFXConfig vFXConfig, GameConfig gameConfig, ChooseModeButtonFactory chooseModeButtonFactory)
        {
            _vfxConfig = vFXConfig;
            _gameConfig = gameConfig;
            SubscribeButtons();

            _settingsMenu.Initialize(_vfxConfig);
            _chooseGameModeMenu.Initialize(_gameConfig, chooseModeButtonFactory, _contentPanel);
        }

        private void SubscribeButtons()
        {
            Extensions.Subscribe(_startGameBtn, StartGame);
            Extensions.Subscribe(_chooseGameModeBtn, () => ActivatePanel(_chooseGameModeMenu.gameObject));
            Extensions.Subscribe(_settingsBtn, () => ActivatePanel(_settingsMenu.gameObject));
        }

        private void StartGame()
        {
            SceneLoader.LoadSceneByBuildIndex(1);
        }

        private void ActivatePanel(GameObject panel)
        {
            panel.SetActive(!panel.activeInHierarchy);
            panel.transform.SetAsLastSibling();
        }
    }
}