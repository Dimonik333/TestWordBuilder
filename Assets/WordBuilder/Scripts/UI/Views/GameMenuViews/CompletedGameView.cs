using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WordBuilder
{
    public sealed class CompletedGameView : UIView
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private AudioClip _audioClip;

        public event UnityAction MainMenuButtonClicked
        {
            add => _mainMenuButton.onClick.AddListener(value);
            remove => _mainMenuButton.onClick.RemoveListener(value);
        }

        public event UnityAction NextLevelButtonClicked
        {
            add => _nextLevelButton.onClick.AddListener(value);
            remove => _nextLevelButton.onClick.RemoveListener(value);
        }

        public void PlayAudio()
        {
            SoundManager.Instance.Play(_audioClip);
        }

        public string Text
        {
            set => _text.text = value;
        }
    }
}