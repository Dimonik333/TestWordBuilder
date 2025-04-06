using UnityEngine;

namespace WordBuilder
{
    public sealed class CompletedGameMenu : MonoBehaviour
    {
        private CompletedGameModel _model;
        private CompletedGamePresenter _presenter;

        [SerializeField] private GameField _gameField;
        [SerializeField] private CompletedGameView _view;

        private void Start()
        {
            _model = new ();
            _presenter = new ();
            _presenter.Initialize(_model, _view);
        }

        private void OnEnable()
        {
            _presenter.Activate();
        }

        private void OnDisable()
        {
            _presenter.Deactivate();
        }
    }
}