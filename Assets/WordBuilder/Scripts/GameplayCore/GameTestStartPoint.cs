using UnityEngine;


namespace WordBuilder
{
    public sealed class GameTestStartPoint : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;

        public void StartGame()
        {
            var words = new string[][]
            {
                new string[]{ "��", "��", "��"},
                new string[]{ "��","����",},
                new string[]{ "���","���",},
                new string[]{ "��","����",}
            };
            _gameField.Init(words);
        }

        [ContextMenu("Check")]
        public void Check()
        {
            var res = _gameField.IsCompleted();
        }
    }
}
