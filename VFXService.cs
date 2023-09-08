using System.Collections;
using TMPro;
using UI.Interfaces;
using UnityEngine;
using Utils;
using Random = System.Random;

namespace VFX
{
    public class VFXService
    {
        private readonly VFXConfig _vfxConfig;
        private readonly AudioSource _audioSource;
        private readonly MotivatingPhrasesConfig _motivatingPhrasesConfig;
        private readonly TMP_Text _motivatingPhraseText;
        private readonly IPointsCounter _pointsCounter;
        private readonly IQuestionsCounter _questionsCounter;

        public VFXService(VFXConfig vfxConfig, AudioSource audioSource, MotivatingPhrasesConfig motivatingPhrasesConfig,
            TMP_Text motivatingPhraseText, IPointsCounter pointsCounter, IQuestionsCounter questionsCounter)
        {
            _vfxConfig = vfxConfig;
            _audioSource = audioSource;
            _motivatingPhrasesConfig = motivatingPhrasesConfig;
            _motivatingPhraseText = motivatingPhraseText;
            _pointsCounter = pointsCounter;
            _questionsCounter = questionsCounter;

            _audioSource.volume = _vfxConfig.Volume;
        }

        public void PlayNextAnswerSound()
        {
            _audioSource.PlayOneShot(_vfxConfig.NextQuestionAudio);
        }

        public void CountFraction()
        {
            SetPhrase(ChoosePhrase());
        } 

        private void SetPhrase(string phrase)
        {
            CoroutineExtension.StartRoutine(PrintText(phrase));
            _audioSource.PlayOneShot(_vfxConfig.PrintPhraseSound);
        }

        private IEnumerator PrintText(string phrase)
        {
            foreach (var letter in phrase)
            {
                _motivatingPhraseText.text += letter;
                yield return new WaitForSeconds(_vfxConfig.PrintTime);
            }
        }

        private string ChoosePhrase()
        {
            float a = (float) _pointsCounter.PointsCounter / (float) _questionsCounter.QuestionsCounter;
            Random random = new Random();

            if (a <= 0.25f)
            {
                var randomIndex = random.Next(0, _motivatingPhrasesConfig.LessThanQuarterPhrases.Length);
                var phrase = _motivatingPhrasesConfig.LessThanQuarterPhrases[randomIndex];
                PlaySound(_vfxConfig.LoseSounds);
                return phrase;
            }
            if (a > 0.25f && a < 0.5f)
            {
                var randomIndex = random.Next(0, _motivatingPhrasesConfig.LessThanHalfPhrases.Length);
                var phrase = _motivatingPhrasesConfig.LessThanHalfPhrases[randomIndex];
                PlaySound(_vfxConfig.LoseSounds);
                return phrase;
            }
            if (a == 1f)
            {
                var randomIndex = random.Next(0, _motivatingPhrasesConfig.AllCorrect.Length);
                var phrase = _motivatingPhrasesConfig.AllCorrect[randomIndex];
                PlaySound(_vfxConfig.VictorySounds);
                return phrase;
            }
            if (a >= 0.5f && a < 1f)
            {
                var randomIndex = random.Next(0, _motivatingPhrasesConfig.MoreThanHalfPhrases.Length);
                var phrase = _motivatingPhrasesConfig.MoreThanHalfPhrases[randomIndex];
                PlaySound(_vfxConfig.AlmostWinSounds);
                return phrase;
            }

            return null;
        }

        private void PlaySound(AudioClip[] audios)
        {
            Random random = new Random();
            var randomIndex = random.Next(0, audios.Length);
            _audioSource.PlayOneShot(audios[randomIndex]);
        }
    }
}
