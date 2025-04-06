using System;
using UnityEngine;

namespace WordBuilder
{
    public sealed class MainMenuView : UIView
    {
        [SerializeField] private StartMenuView _startView;
        [SerializeField] private SettingsMenuView _settingsView;

        public StartMenuView StartMenuView => _startView;
        public SettingsMenuView SettingsMenuView => _settingsView;
    }
}