using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        public TMP_Text MotivatingPhraseText;

        [Header("Buttons")]
        [SerializeField] private Button _backToMenuBtn;
        [SerializeField] private Button _restartButton;

        public void Initilize()
        {
            MotivatingPhraseText.text = null;
            Extensions.Subscribe(_backToMenuBtn, LoadMenu);
            Extensions.Subscribe(_restartButton, RestartGame);
        }

        private void LoadMenu()
        {
            SceneLoader.LoadSceneByBuildIndex(0);
        }

        private void RestartGame()
        {
            SceneLoader.LoadSceneByBuildIndex(1);
        }
    }
}
