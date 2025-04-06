

namespace WordBuilder
{
    public sealed class CompletedGameModel : UIModel
    {
        private readonly GameField _gameField;

        public string Text
        {
            get => _gameField.Result();
        }

        public void MainMenu()
        {
            SceneTransitionManager.Instance.ChangeScene("Main");
        }

        public void NextLevel()
        {
            SceneTransitionManager.Instance.ChangeScene("Game");
        }
    }
}