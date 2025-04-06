using System;

namespace WordBuilder
{
    public sealed class SettingsMenuPresenter : UIPresenter<SettingsMenuModel, SettingsMenuView>
    {
        public event Action SettingsClosed;

        protected override void OnActivate()
        {
            _view.VolumeValueChanged += OnVolumeValueChanged;
            _view.CloseButtonClicked += OnCloseButtonClicked;
        }

        protected override void OnDeactivate()
        {
            _view.VolumeValueChanged -= OnVolumeValueChanged;
            _view.CloseButtonClicked -= OnCloseButtonClicked;
        }

        private void OnVolumeValueChanged(float value)
        {
            _model.Volume = value;
        }

        public void ShowView()
            => _view.Show();

        public void HideView()
        {
            _view.Hide();
            SettingsClosed();
        }

        private void OnCloseButtonClicked()
            => HideView();

        protected override void OnInitialize()
        {
            _view.Volume = _model.Volume;
        }
    }
}