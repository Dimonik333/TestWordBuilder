namespace WordBuilder
{
    public sealed class MainMenuPresenter : UIPresenter<MainMenuModel, MainMenuView>
    {
        private readonly StartMenuPresenter _startMenuPresenter;
        private readonly SettingsMenuPresenter _settingsMenuPresenter;

        public MainMenuPresenter(StartMenuPresenter startMenuPresenter, SettingsMenuPresenter settingsMenuPresenter)
        {
            _startMenuPresenter = startMenuPresenter;
            _settingsMenuPresenter = settingsMenuPresenter;
        }

        protected override void OnActivate()
        {
            _startMenuPresenter.Activate();
            _settingsMenuPresenter.Activate();

            _startMenuPresenter.SettingsRequested += OnSettingsRequested;
            _settingsMenuPresenter.SettingsClosed += OnSettingsClosed;
        }

        protected override void OnDeactivate()
        {
            _startMenuPresenter.Deactivate();
            _settingsMenuPresenter.Deactivate();

            _startMenuPresenter.SettingsRequested -= OnSettingsRequested;
            _settingsMenuPresenter.SettingsClosed -= OnSettingsClosed;
        }

        protected override void OnInitialize()
        {
            _startMenuPresenter.Initialize(_model.StartMenuModel, _view.StartMenuView);
            _settingsMenuPresenter.Initialize(_model.SettingsMenuModel, _view.SettingsMenuView);
        }

        private void OnSettingsRequested()
        {
            _settingsMenuPresenter.ShowView();
            _startMenuPresenter.Interactable = false;
            // блокируем ввод для start
        }

        private void OnSettingsClosed()
        {
            _startMenuPresenter.Interactable = true;
            // разблокировать ввод для start
        }
    }
}