using Answers;
using System;
using TMPro;
using UnityEngine;

namespace Questions
{
    public class QuestionView : MonoBehaviour
    {
        public Transform AnswersPanel;
        public TMP_Text QuestionText;

        public event Action OnDestroyHandler;

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}