using System;
using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(fileName = "Question Configs", menuName = "Configs / New Question Configs")]
    public class QuestionConfigs : ScriptableObject
    {
        [SerializeField] private Config _remarque, _stephenKing, _harryPotter, _gerbertWells, _tolkien, _tolstoy, _dostoevsky;

        public Config GetConfig(QuestionType questionType)
        {
            switch (questionType)
            {
                case QuestionType.ErichMariaRemarque:
                    return _remarque;
                case QuestionType.StephenKing:
                    return _stephenKing;
                case QuestionType.JoanneRowling:
                    return _harryPotter;
                case QuestionType.GerbertWells: 
                    return _gerbertWells;
                case QuestionType.JohnRonaldReuelTolkien:
                    return _tolkien;
                case QuestionType.LeoTolstoy:
                    return _tolstoy;
                case QuestionType.FyodorDostoevsky:
                    return _dostoevsky;
            }

            Debug.Log($"No config for {questionType}");
            return null;
        }
    }

    [Serializable]
    public class Config
    {
        public QuestionConfig[] Questions;
    }
}
