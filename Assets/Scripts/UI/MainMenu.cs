using UnityEngine;

namespace WordBuilder
{
    public sealed class MainMenu : MonoBehaviour
    {
        private MainMenuModel _model;
        private MainMenuPresenter _presenter;

        [SerializeField] private MainMenuView _view;

        private void Awake()
        {
            _model = new MainMenuModel(new StartMenuModel(), new SettingsMenuModel());
            _presenter = new MainMenuPresenter(new StartMenuPresenter(), new SettingsMenuPresenter());
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