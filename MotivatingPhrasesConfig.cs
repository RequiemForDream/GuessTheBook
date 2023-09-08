using UnityEngine;

namespace VFX
{
    [CreateAssetMenu]
    public class MotivatingPhrasesConfig : ScriptableObject
    {
        [TextArea(1, 2)]
        public string[] LessThanQuarterPhrases;
        [TextArea(1, 2)]
        public string[] LessThanHalfPhrases;
        [TextArea(1, 2)]
        public string[] MoreThanHalfPhrases;
        [TextArea(1, 2)]
        public string[] AllCorrect;
    }
}
