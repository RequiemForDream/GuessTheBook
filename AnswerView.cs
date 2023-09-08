using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Answers
{
    public class AnswerView : MonoBehaviour, IPointerClickHandler
    {
        public TMP_Text AnswerText;
        public Image AnswerBackground;

        public event Action<string> OnAnswerClick;
        public event Action OnDestroyHandler;

        public bool IsInteractable
        {
            set
            {
                AnswerBackground.raycastTarget = value;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnAnswerClick?.Invoke(AnswerText.text);
        }

        public void SetTextColor(Color color)
        {
            AnswerText.color = color;
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}
