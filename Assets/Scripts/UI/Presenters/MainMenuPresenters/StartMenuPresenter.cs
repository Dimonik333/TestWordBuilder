using System;

namespace WordBuilder
{
    public sealed class StartMenuPresenter : UIPresenter<StartMenuModel, StartMenuView>
    {
        public bool Interactable { get; internal set; }

        public event Action SettingsRequested;

        protected override void OnActivate()
        {
            _view.StartButtonClicked += OnStartButtonClicked;
            _view.SettingsButtonClicked += OnSettingsButtonClicked;
        }

        protected override void OnDeactivate()
        {
            _view.StartButtonClicked -= OnStartButtonClicked;
            _view.SettingsButtonClicked -= OnSettingsButtonClicked;
        }

        protected override void OnInitialize() { }

        private void OnStartButtonClicked()
        {
            _model.StartGame();
        }

        private void OnSettingsButtonClicked()
        {
            SettingsRequested?.Invoke();
        }
    }
}