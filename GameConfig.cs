using Questions;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        public QuestionType GameMode;
        public QuestionType[] GameModesAmount;
    }
}
