

namespace WordBuilder
{
    public sealed class ActiveGameModel : UIModel
    {
        private readonly GameField _gameField;
        private readonly ActiveGameMenu _activeGameMenu;
        private readonly CompletedGameMenu _completedGameMenu;

        public void Check()
        {
            if (!_gameField.IsCompleted())
                return;

            // up progress

            _activeGameMenu.gameObject.SetActive(false);
            _completedGameMenu.gameObject.SetActive(true);
        }
    }
}