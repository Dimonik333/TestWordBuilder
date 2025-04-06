using System;
using UnityEngine;

namespace WordBuilder
{
    public sealed class MainMenuModel : UIModel
    {
        private readonly StartMenuModel _startMenuModel;
        private readonly SettingsMenuModel _settingsMenuModel;

        public MainMenuModel(StartMenuModel startMenuModel, SettingsMenuModel settingsMenuModel)
        {
            _startMenuModel = startMenuModel;
            _settingsMenuModel = settingsMenuModel;
        }

        public StartMenuModel StartMenuModel => _startMenuModel;
        public SettingsMenuModel SettingsMenuModel => _settingsMenuModel;
    }
}