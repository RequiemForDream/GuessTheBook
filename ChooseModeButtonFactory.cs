using ChooseModeButtons;
using Factories.Interfaces;
using Object = UnityEngine.Object;

namespace Factories.MenuScene
{
    public class ChooseModeButtonFactory : IFactory<ChooseModeButton>
    {
        private readonly ChooseModeButtonConfig _chooseModeButtonConfig;

        public ChooseModeButtonFactory(ChooseModeButtonConfig chooseModeButtonConfig)
        {
            _chooseModeButtonConfig = chooseModeButtonConfig;
        }

        public ChooseModeButton Create()
        {
            ChooseModeButtonView buttonView = Object.Instantiate(_chooseModeButtonConfig.ChooseModeButtonView);

            ChooseModeButton button = new ChooseModeButton(buttonView, _chooseModeButtonConfig.ChooseModeButtonModel);

            return button;
        }
    }
}
