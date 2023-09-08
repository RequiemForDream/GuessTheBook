using Answers;
using Core.Interfaces;
using Factories;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Questions
{
    public class Question : IInitialize
    {
        public readonly QuestionView QuestionView;
        public readonly QuestionModel QuestionModel;

        public event Action OnAnswerClick;

        private readonly AnswerFactory _answerFactory;
        private readonly PointsCounter _pointsCounter;
        private readonly AudioSource _audioSource;

        private List<Answer> _answers = new List<Answer>();

        public Question(QuestionView questionView, QuestionModel questionModel, AnswerFactory answerFactory, PointsCounter pointsCounter,
            AudioSource audioSource)
        {
            QuestionView = questionView;
            QuestionModel = questionModel;
            _answerFactory = answerFactory;
            _pointsCounter = pointsCounter;
            _audioSource = audioSource;
        }

        public void Initialize()
        {
            SetQuestionText(QuestionModel.QuestionText);
            InitializeAnswers();

            QuestionView.OnDestroyHandler += Destroy;
        }

        private void InitializeAnswers()
        {
            for (int i = 0; i < QuestionModel.Answers.Length; i++)
            {
                var answer = _answerFactory.Create();
                answer.Initialize(QuestionView.AnswersPanel, this.QuestionModel.Answers[i]);
                answer.OnAnswerClick += CheckAnswer;
                _answers.Add(answer);
            }
        }

        private void SetQuestionText(string QuestionText)
        {
            QuestionView.QuestionText.text = QuestionText;
        }

        private void CheckAnswer(string text, Answer answer)
        {
            OnAnswerClick?.Invoke();
            if (text == QuestionModel.CorrectAnswer)
            {
                answer.AnswerView.SetTextColor(QuestionModel.CorrectAnswerColor);
                _audioSource.PlayOneShot(QuestionModel.CorrectAnswerSound);
                _pointsCounter.AddPoints(QuestionModel.PointsToAdd);
            }
            else
            {
                answer.AnswerView.SetTextColor(QuestionModel.WrongAnswerColor);
                _audioSource.PlayOneShot(QuestionModel.WrongAnswerSound);
            }

            foreach (var answerView in _answers)
            {
                answerView.AnswerView.IsInteractable = false;
            }
        }

        private void Destroy()
        {
            QuestionView.OnDestroyHandler -= Destroy;
            foreach (var answer in _answers)
            {
                answer.OnAnswerClick -= CheckAnswer;
            }
        }
    }
}

