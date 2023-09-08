using Questions;
using UnityEngine;

namespace ChooseModeButtons
{
    public class ChooseModeButton
    {
        public readonly ChooseModeButtonView ChooseModeButtonView;
        public readonly ChooseModeButtonModel ChooseModeButtonModel;
        public QuestionType GameMode;

        public ChooseModeButton(ChooseModeButtonView chooseModeButtonView, ChooseModeButtonModel chooseModeButtonModel)
        {
            ChooseModeButtonView = chooseModeButtonView;
            ChooseModeButtonModel = chooseModeButtonModel;
        }

        public void Initialize(Transform transform, QuestionType questionType)
        {
            ChooseModeButtonView.transform.SetParent(transform, false);
            GameMode = questionType;
            ChooseModeButtonView.SetText(questionType);
        }
    }
}
