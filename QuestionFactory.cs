using Core;
using Factories.Interfaces;
using Questions;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories
{
    public class QuestionFactory : IFactory<Question>
    {
        public event Action OnQuestionsHasEnded;

        private readonly QuestionConfigs _questionConfigs;
        private readonly AnswerFactory _answerFactory;
        private readonly Transform _questionsParent;
        private readonly PointsCounter _pointsCounter;
        private readonly GameConfig _gameConfig;
        private readonly AudioSource _audioSource;

        private List<QuestionConfig> _questions = new List<QuestionConfig>(); 
        private int number = 0;

        public QuestionFactory(QuestionConfigs questionConfigs, AnswerFactory answerFactory, Transform questionsParent,
            PointsCounter pointsCounter, GameConfig gameConfig, AudioSource audioSource)
        {
            _questionConfigs = questionConfigs;
            _answerFactory = answerFactory;
            _questionsParent = questionsParent;
            _pointsCounter = pointsCounter;
            _gameConfig = gameConfig;
            _audioSource = audioSource;

            AddQuestions();
        }

        public Question Create()
        {
            if (number == _questions.Count)
            {
                OnQuestionsHasEnded?.Invoke();
                return null;
            }

            QuestionView questionView = Object.Instantiate(_questions[number].QuestionView, _questionsParent);
            
            Question question = new Question(questionView, _questions[number].QuestionModel, _answerFactory,
               _pointsCounter, _audioSource);

            number++;

            return question;
        }

        public void Reclaim(Object obj)
        {
            Object.Destroy(obj);
        }

        private void AddQuestions()
        {
            var config = _questionConfigs.GetConfig(_gameConfig.GameMode);
            var questions = config.Questions;
            _questions.AddRange(questions);
        }
    }
}
