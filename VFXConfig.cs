using UnityEngine;

namespace VFX
{
    [CreateAssetMenu(fileName = "VFX Config", menuName = "Config / New VFX Config")]
    public class VFXConfig : ScriptableObject
    {
        public float Volume;

        [Header("Audios")]
        [SerializeField] private AudioClip _nextQuestionAudio;
        [SerializeField] private AudioClip _printPhraseSound;
        [SerializeField] private AudioClip[] _victorySounds;
        [SerializeField] private AudioClip[] _almostWinSounds;
        [SerializeField] private AudioClip[] _loseSounds;
        public AudioClip NextQuestionAudio => _nextQuestionAudio;
        public AudioClip PrintPhraseSound => _printPhraseSound; 
        public AudioClip[] VictorySounds => _victorySounds;
        public AudioClip[] AlmostWinSounds => _almostWinSounds;
        public AudioClip[] LoseSounds => _loseSounds;   

        private float _printTime = 0.05f;
        public float PrintTime => _printTime;
    }
}
