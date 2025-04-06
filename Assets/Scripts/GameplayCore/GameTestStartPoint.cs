using UnityEngine;


namespace WordBuilder
{
    public sealed class GameTestStartPoint : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;

        private void Start()
        {
            var words = new string[][]
            {
                new string[]{ "ма", "ли", "на"},
                new string[]{ "ма","шина",},
                new string[]{ "кор","ова",},
                new string[]{ "ко","рона",}
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
