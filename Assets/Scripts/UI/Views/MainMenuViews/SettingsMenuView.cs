using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WordBuilder
{
    public sealed class SettingsMenuView : UIView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _slider;

        public event UnityAction CloseButtonClicked
        {
            add => _closeButton.onClick.AddListener(value);
            remove => _closeButton.onClick.RemoveListener(value);
        }

        public event UnityAction<float> VolumeValueChanged
        {
            add => _slider.onValueChanged.AddListener(value);
            remove => _slider.onValueChanged.RemoveListener(value);
        }

        public float Volume
        {
            get => _slider.value;
            set => _slider.value = value;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}