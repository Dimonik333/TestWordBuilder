

namespace WordBuilder
{
    public sealed class CompletedGameModel : UIModel
    {
        private readonly GameField _gameField;

        public CompletedGameModel(GameField gameField)
        {
            _gameField = gameField;
        }

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