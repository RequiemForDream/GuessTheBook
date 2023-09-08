using UnityEngine;
using UnityEngine.UI;
using Utils;
using VFX;

namespace UI.MenuScene
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Slider _volumeSlider;

        private VFXConfig _vfxConfig;

        public void Initialize(VFXConfig vFXConfig)
        {
            _vfxConfig = vFXConfig;
            SetVolumeSlider();
            _volumeSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
            Extensions.Deactivate(this.gameObject);
        }

        private void OnValueChanged()
        {
            _vfxConfig.Volume = _volumeSlider.value;
        }

        private void SetVolumeSlider()
        {
            _volumeSlider.value = _vfxConfig.Volume;
        }
    }
}