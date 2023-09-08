using Core;
using Factories.MenuScene;
using Questions;
using UnityEngine;
using Utils;

namespace UI.MenuScene
{
    public class ChooseGameModeMenu : MonoBehaviour
    {
        private ChooseModeButtonFactory _chooseModeButtonFactory;
        private GameConfig _gameConfig;
        private Transform _contentPanel;

        public void Initialize(GameConfig gameConfig, ChooseModeButtonFactory chooseModeButtonFactory, Transform content)
        {
            _gameConfig = gameConfig;
            _chooseModeButtonFactory = chooseModeButtonFactory;
            _contentPanel = content;

            AddButtons();
            Extensions.Deactivate(this.gameObject);
        }

        private void AddButtons()
        {
            for (int i = 0; i < _gameConfig.GameModesAmount.Length; i++)
            {
                var button = _chooseModeButtonFactory.Create();
                var gameMode = _gameConfig.GameModesAmount[i];
                button.Initialize(_contentPanel, gameMode);
                Extensions.Subscribe(button.ChooseModeButtonView.ChooseGameModeBtn, () => Subscribe(button.GameMode));
            }
        }

        private void Subscribe(QuestionType gameMode)
        {
            _gameConfig.GameMode = gameMode;
        }
    }
}