using UnityEngine;

namespace Answers
{
    [CreateAssetMenu(fileName = "Answer Config", menuName = "Config / New Answer Config")]
    public class AnswerConfig : ScriptableObject
    {
        public AnswerView AnswerView;
        public AnswerModel AnswerModel;
    }
}
