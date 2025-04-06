using CatCode;
using CatCode.Commands;
using UnityEngine.SceneManagement;

namespace WordBuilder
{
    [ObjectCreationConfig(
        creationMode: ObjectCreationMode.FindOnScene | ObjectCreationMode.CreateNewInstance,
        dontDestroyOnLoad: true,
        instanceName: nameof(SceneTransitionManager))]
    public sealed class SceneTransitionManager : MonoSingleton<SceneTransitionManager>
    {
        private ICommand _command;

        public void ChangeScene(string sceneName)
        {
            _command?.Stop();
            _command = new SceneLoadCommand(sceneName, LoadSceneMode.Single)
                .AddOnStarted(() =>
                {
                    SceneController.CurrentSceneActions.InvokeAction(SceneActionLifePoint.BeforeFadeIn);
                    FadeManager.Instance.BlackFade.Show();
                    SceneController.CurrentSceneActions.InvokeAction(SceneActionLifePoint.AfterFadeIn);
                })
                .AddOnFinished(() =>
                {
                    SceneController.CurrentSceneActions.InvokeAction(SceneActionLifePoint.BeforeFadeOut);
                    FadeManager.Instance.BlackFade.Hide();
                    SceneController.CurrentSceneActions.InvokeAction(SceneActionLifePoint.AfterFadeOut);
                });
            _command.Execute();
        }
    }
}