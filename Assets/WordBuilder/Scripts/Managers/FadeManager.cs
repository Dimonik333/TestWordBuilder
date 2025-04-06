using CatCode;
using System;
using UnityEngine;

namespace WordBuilder
{
    [ObjectCreationConfig(
       creationMode: ObjectCreationMode.FindOnScene | ObjectCreationMode.LoadFromResources,
       dontDestroyOnLoad: true,
       instanceName: nameof(FadeManager),
       resourceName: "Singletons/" + nameof(FadeManager))]
    public sealed class FadeManager : MonoSingleton<FadeManager>
    {
        [SerializeField] private FadeScreen _blackFade;
        public FadeScreen BlackFade => _blackFade;

    }
}