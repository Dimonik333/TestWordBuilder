using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace WordBuilder
{
    public sealed class ActiveGameView : UIView
    {
        [SerializeField] private Button _checkButton;

        public event UnityAction CheckButtonClicked
        {
            add => _checkButton.onClick.AddListener(value);
            remove => _checkButton.onClick.RemoveListener(value);
        }
    }
}