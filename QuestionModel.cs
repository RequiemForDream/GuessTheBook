using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public class QuestionModel
    {
        [TextArea(5, 10)]
        public string QuestionText;

        [TextArea(1, 2)]
        public string[] Answers;

        [TextArea(1, 2)]
        public string CorrectAnswer;

        public int PointsToAdd = 1;

        [Header("Colors")]
        [SerializeField] private Color _correctAnswerColor;
        [SerializeField] private Color _wrongAnswerColor;

        public Color CorrectAnswerColor => _correctAnswerColor;
        public Color WrongAnswerColor => _wrongAnswerColor;

        [Header("AnswerSounds")]
        [SerializeField] private AudioClip _correctAnswerSound;
        [SerializeField] private AudioClip _wrongAnswerSound;

        public AudioClip CorrectAnswerSound => _correctAnswerSound;
        public AudioClip WrongAnswerSound => _wrongAnswerSound;
    }
}
