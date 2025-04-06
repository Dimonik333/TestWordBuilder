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

        public string Text
        {
            set => _text.text = value;
        }
    }
}