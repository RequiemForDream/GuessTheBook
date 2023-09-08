using System;
using UnityEngine;

namespace Answers
{
    public class Answer
    {
        public readonly AnswerView AnswerView;
        public readonly AnswerModel AnswerModel;

        public event Action<string, Answer> OnAnswerClick;

        public Answer(AnswerView answerView, AnswerModel answerModel)
        {
            AnswerView = answerView;
            AnswerModel = answerModel;
        }

        public void Initialize(Transform parent, string answerText)
        {
            AnswerView.transform.SetParent(parent, false);
            AnswerView.AnswerText.text = answerText;

            AnswerView.OnAnswerClick += OnAnswerClicked;
            AnswerView.OnDestroyHandler += Destroy;
        }

        private void OnAnswerClicked(string text)
        {
            OnAnswerClick?.Invoke(text, this);
        }

        private void Destroy()
        {
            AnswerView.OnAnswerClick -= OnAnswerClicked;
            AnswerView.OnDestroyHandler -= Destroy;
        }
    }
}
