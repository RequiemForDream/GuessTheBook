using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(fileName = "Question Config", menuName = "Config / New Question Config")]
    public class QuestionConfig : ScriptableObject
    {
        public QuestionView QuestionView;
        public QuestionModel QuestionModel;
    }
}
