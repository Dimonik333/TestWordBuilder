using UnityEngine;

namespace WordBuilder
{
    public sealed class ActiveGameMenu : MonoBehaviour
    {
        private ActiveGameModel _model;
        private ActiveGamePresenter _presenter;
        [SerializeField] private GameField _gameField;

        [SerializeField] private ActiveGameView _view;
        private void Start()
        {
            _model = new ActiveGameModel();
            _presenter = new ActiveGamePresenter();
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