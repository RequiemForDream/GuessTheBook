using UnityEngine;

namespace ChooseModeButtons
{
    [CreateAssetMenu(fileName = "Choose Mode Button Config", menuName = "Config / New Button Config")]
    public class ChooseModeButtonConfig : ScriptableObject
    {
        public ChooseModeButtonView ChooseModeButtonView;
        public ChooseModeButtonModel ChooseModeButtonModel;
    }
}
