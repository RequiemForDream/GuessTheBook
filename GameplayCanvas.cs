using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class GameplayCanvas : CanvasModel
    {
        public GameOverScreen GameOverScreen;

        [SerializeField] private TMP_Text _pointsCount;
        [SerializeField] private TMP_Text _questionsCount;

        private PointsCounter _pointsCounter;
        private QuestionsCounter _questionsCounter;

        public void Initialize(PointsCounter pointsCounter, QuestionsCounter questionsCounter)
        {
            _pointsCounter = pointsCounter;
            _questionsCounter = questionsCounter;

            pointsCounter.OnValueChanged += UpdatePointsValue;
            questionsCounter.OnValueChanged += UpdateQuestionsValue;

            Extensions.Deactivate(GameOverScreen.gameObject);
            UpdatePointsValue(0);
        }

        public void ActivateGameOverScreen()
        {
            Extensions.Activate(GameOverScreen.gameObject);
            GameOverScreen.Initilize();
        }

        private void UpdatePointsValue(int value)
        {
            _pointsCount.text = "Correct Answers: " + value.ToString();
        }

        private void UpdateQuestionsValue(int value)
        {
            _questionsCount.text = value.ToString();
        }

        private void OnDestroy()
        {
            _pointsCounter.OnValueChanged -= UpdatePointsValue;
            _questionsCounter.OnValueChanged -= UpdateQuestionsValue;
        }
    }
}
