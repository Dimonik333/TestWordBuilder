namespace WordBuilder
{
    public sealed class SettingsMenuModel : UIModel
    {
        public float Volume
        {
            get => SoundManager.Instance.MasterVolume;
            set => SoundManager.Instance.MasterVolume = value;
        }
    }
}