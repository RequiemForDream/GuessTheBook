using Questions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChooseModeButtons
{
    public class ChooseModeButtonView : MonoBehaviour
    {
        public Button ChooseGameModeBtn;
        [SerializeField] private TMP_Text _buttonName;

        public void SetText(QuestionType gameMode)
        {
            _buttonName.text = gameMode.ToString();
        }
    }
}
