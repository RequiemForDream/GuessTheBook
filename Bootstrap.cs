using Answers;
using Factories;
using Questions;
using UI;
using UnityEngine;
using VFX;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private QuestionConfigs _questionConfigs;
        [SerializeField] private AnswerConfigs _answerConfigs;
        [SerializeField] private MotivatingPhrasesConfig _motivatingPhrasesConfig;
        [SerializeField] private VFXConfig _vfxConfig;
        [SerializeField] private GameConfig _gameConfig;

        [Header("Stuff")]
        [SerializeField] private Transform _questionsParent;
        [SerializeField] private AudioSource _audioSource;

        [Header("UI")]
        [SerializeField] private GameplayCanvas _gameplayCanvas;

        private void Awake()
        {
            BindCounters(out QuestionsCounter questionsCounter, out PointsCounter pointsCounter);

            _gameplayCanvas.Initialize(pointsCounter, questionsCounter);

            BindFactories(out VFXService vFXFactory, out AnswerFactory answerFactory, out QuestionFactory questionFactory,
            pointsCounter, questionsCounter);

            BindGameScenario(out GameScenario gameScenario, questionFactory, vFXFactory, questionsCounter);
            gameScenario.Initialize();
        }

        private void BindCounters(out QuestionsCounter questionsCounter, out PointsCounter pointsCounter)
        {
            PointsCounter newPointsCounter = new PointsCounter();
            pointsCounter = newPointsCounter;

            QuestionsCounter newQuestionsCounter = new QuestionsCounter();
            questionsCounter = newQuestionsCounter;
        }

        private void BindFactories(out VFXService vFXFactory, out AnswerFactory answerFactory, out QuestionFactory questionFactory,
            PointsCounter pointsCounter, QuestionsCounter questionsCounter)
        {
            VFXService newVfXFactory = new VFXService(_vfxConfig, _audioSource, _motivatingPhrasesConfig,
                _gameplayCanvas.GameOverScreen.MotivatingPhraseText, pointsCounter, questionsCounter);
            vFXFactory = newVfXFactory;

            AnswerFactory newAnswerFactory = new AnswerFactory(_answerConfigs);
            answerFactory = newAnswerFactory;

            QuestionFactory newQuestionFactory = new QuestionFactory(_questionConfigs, newAnswerFactory, _questionsParent,
                pointsCounter, _gameConfig, _audioSource);
            questionFactory = newQuestionFactory;
        }

        private void BindGameScenario(out GameScenario gameScenario, QuestionFactory questionFactory, VFXService vFXFactory,
            QuestionsCounter questionsCounter)
        {
            GameScenario newGameScenario = new GameScenario(questionFactory, vFXFactory, questionsCounter, _gameplayCanvas);
            gameScenario = newGameScenario;
        }
    }
}

