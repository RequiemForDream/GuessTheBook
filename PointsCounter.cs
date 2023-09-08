using System;
using UI.Interfaces;

namespace UI
{
    public class PointsCounter : IPointsCounter
    {
        public event Action<int> OnValueChanged;
        private int _pointsCounter;

        int IPointsCounter.PointsCounter { get => _pointsCounter; }

        public void AddPoints(int value)
        {
            _pointsCounter += value;
            OnValueChanged?.Invoke(_pointsCounter);
        }
    }
}
