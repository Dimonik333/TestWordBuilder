using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WordBuilder
{
    public sealed class StartMenuView : UIView
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private CanvasGroup _canvasGroup;

        public event UnityAction StartButtonClicked
        {
            add => _startButton.onClick.AddListener(value);
            remove => _startButton.onClick.RemoveListener(value);
        }

        public event UnityAction SettingsButtonClicked
        {
            add => _settingsButton.onClick.AddListener(value);
            remove => _settingsButton.onClick.RemoveListener(value);
        }

        public bool Interactable
        {
            set => _canvasGroup.blocksRaycasts = value;
        }
    }
}