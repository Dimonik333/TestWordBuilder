

using UnityEngine.UI;

namespace WordBuilder
{
    public sealed class ActiveGameModel : UIModel
    {
        private readonly GameField _gameField;
        private readonly ActiveGameMenu _activeGameMenu;
        private readonly CompletedGameMenu _completedGameMenu;

        public ActiveGameModel(GameField gameField, ActiveGameMenu activeGameMenu, CompletedGameMenu completedGameMenu)
        {
            _gameField = gameField;
            _activeGameMenu = activeGameMenu;
            _completedGameMenu = completedGameMenu;
        }

        public void Check()
        {
            if (!_gameField.IsCompleted())
                return;

            GameManager.CompleteLevel();
                        
            _activeGameMenu.gameObject.SetActive(false);
            _completedGameMenu.gameObject.SetActive(true);
        }
    }
}