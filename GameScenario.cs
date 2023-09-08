using Answers;
using Core.Interfaces;
using Factories;
using Questions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using Utils;
using VFX;

namespace Core
{
    public class GameScenario : IInitialize
    {
        private readonly QuestionFactory _questionFactory;
        private readonly VFXService _vFXFactory;
        private readonly QuestionsCounter _questionsCounter;
        private readonly GameplayCanvas _gameplayCanvas;

        private List<Question> _questions = new List<Question>();

        public GameScenario(QuestionFactory questionFactory, VFXService vFXFactory, QuestionsCounter questionsCounter,
            GameplayCanvas gameplayCanvas)
        {
            _questionFactory = questionFactory;
            _vFXFactory = vFXFactory;
            _questionsCounter = questionsCounter;
            _gameplayCanvas = gameplayCanvas;

            _questionFactory.OnQuestionsHasEnded += EndGameSession;
        }

        public void Initialize()
        {
            CreateAnswer();
        }

        private void CheckAnswer()
        {
            CoroutineExtension.StartRoutine(ShowCorrectAnswer());
        }

        private IEnumerator ShowCorrectAnswer()
        {
            yield return new WaitForSeconds(1f);
            RemoveQuestion();
            CreateAnswer();
        }

        private void CreateAnswer()
        {
            var question = _questionFactory.Create();
            if (question != null)
            {
                _vFXFactory.PlayNextAnswerSound();
                question.Initialize();
                question.OnAnswerClick += CheckAnswer;
                _questions.Add(question);
                _questionsCounter.AddValue(1);
            }
        }

        private void RemoveQuestion()
        {
            if (_questions.Count > 0)
            {
                var question = _questions.Last();
                question.OnAnswerClick -= CheckAnswer;
                _questionFactory.Reclaim(question.QuestionView.gameObject);
                _questions.Remove(question);
            }
        }

        private void EndGameSession()
        {
            _gameplayCanvas.ActivateGameOverScreen();
            _vFXFactory.CountFraction();
        }
    }
}
