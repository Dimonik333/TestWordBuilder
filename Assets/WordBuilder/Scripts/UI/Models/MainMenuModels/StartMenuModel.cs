namespace WordBuilder
{
    public sealed class StartMenuModel : UIModel
    {
        public void StartGame()
        {
            SceneTransitionManager.Instance.ChangeScene("Game");
        }
    }
}