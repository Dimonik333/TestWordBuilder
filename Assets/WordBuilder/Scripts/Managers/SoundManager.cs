using CatCode;
using UnityEngine;
using UnityEngine.Audio;

namespace WordBuilder
{
    [ObjectCreationConfig(
       creationMode: ObjectCreationMode.FindOnScene | ObjectCreationMode.LoadFromResources,
       dontDestroyOnLoad: true,
       instanceName: nameof(SoundManager),
       resourceName: "Singletons/" + nameof(SoundManager))]
    public sealed class SoundManager : MonoSingleton<SoundManager>
    {
        private const float MinValue = 0.001f;
        private const float MaxValue = 1.0f;

        [SerializeField] private AudioMixer _audioMixer;
        [Space]
        [SerializeField] private string _masterVolumeName = "MasterVolume";


        public float MasterVolume
        {
            get
            {
                if (_audioMixer.GetFloat(_masterVolumeName, out var volume))
                    return Mathf.Pow(10, volume / 20);
                return 0f;
            }
            set
            {
                value = Mathf.Clamp(value, MinValue, MaxValue);
                var volume = Mathf.Log10(value) * 20;
                _audioMixer.SetFloat(_masterVolumeName, volume);
            }
        }
    }
}