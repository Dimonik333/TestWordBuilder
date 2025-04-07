using UnityEngine;
using Unity.Services.RemoteConfig;
using System.Threading.Tasks;
using Unity.Services.Core;
using System.Threading;
using System;

namespace WordBuilder
{
    public struct userAttributes { }
    public struct appAttributes { }

    public sealed class MainSceneController : SceneController
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private GameObject _loading;

        protected override void Awake()
        {
            base.Awake();
            RegisterAction(SceneActionLifePoint.AfterFadeOut, OnAdterFadeOut);
        }

        private void OnAdterFadeOut()
        {
            Temp();
        }

        private async void Temp()
        {
            _loading.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
            try
            {
                await UnityServices.InitializeAsync();
                var result = await RemoteConfigService.Instance.FetchConfigsAsync(new userAttributes(), new appAttributes());
                var json = result.GetJson("LevelsData");
                var data = JsonUtility.FromJson<LevelCollection>(json);
                GameManager.Load(data);
            }
            catch (Exception e)
            {
            }
            finally
            {
                _loading.SetActive(false);
                _mainMenu.gameObject.SetActive(true);
            }
        }

        public Task EventToTask<T>(
            Action<Action<T>> subscribe,
            Action<Action<T>> unsubscribe,
            CancellationToken token)
        {
            var tcs = new TaskCompletionSource<T>();
            if (token.IsCancellationRequested)
            {
                tcs.SetCanceled();
                return tcs.Task;
            }

            CancellationTokenRegistration ctr = default;
            ctr = token.Register(OnCancel);
            subscribe(EventHandler);

            return tcs.Task;

            void EventHandler(T value)
            {
                unsubscribe(EventHandler);
                ctr.Dispose();
                tcs.SetResult(value);
            }

            void OnCancel()
            {
                unsubscribe(EventHandler);
                ctr.Dispose();
                tcs.SetCanceled();
            }
        }
    }
}