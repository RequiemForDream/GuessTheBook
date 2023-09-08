using System;
using UI.Interfaces;

namespace UI
{
    public class QuestionsCounter : IQuestionsCounter
    {
        public event Action<int> OnValueChanged;
        private int _questionsCounter;

        int IQuestionsCounter.QuestionsCounter => _questionsCounter;

        public void AddValue(int value)
        {
            _questionsCounter += value;
            OnValueChanged?.Invoke(_questionsCounter);
        }
    }
}
