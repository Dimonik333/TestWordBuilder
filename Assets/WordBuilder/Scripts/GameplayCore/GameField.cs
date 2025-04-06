using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;


namespace WordBuilder
{

    public sealed class GameField : MonoBehaviour
    {
        private string[] _targetWords;

        [SerializeField] private WordContainer[] _targetContainers;
        [SerializeField] private WordContainer _container;

        [SerializeField] private RectTransform _dragLayer;
        [SerializeField] private WordBlock _itemPrefab;

        public void Init(string[][] words)
        {
            _targetWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
                _targetWords[i] = string.Concat(words[i]);

            var wordParts = ListPool<string>.Get();

            CopyWordParts(words, wordParts);
            ShuffleParts(wordParts);
            CreateBlock(wordParts);

            ListPool<string>.Release(wordParts);
        }
        public bool IsCompleted()
        {
            return _targetWords.All(targetWord => _targetContainers.Any(c => c.Word == targetWord));
        }

        public string Result()
            => string.Join("\n", _targetContainers.Select(c => c.Word).ToArray());


        private void CopyWordParts(string[][] words, List<string> wordParts)
        {
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                for (int j = 0; j < word.Length; j++)
                    wordParts.Add(word[j]);
            }
        }

        private void ShuffleParts(List<string> wordParts)
        {
            for (int i = wordParts.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i);
                (wordParts[i], wordParts[j]) = (wordParts[j], wordParts[i]);
            }
        }

        private void CreateBlock(List<string> wordParts)
        {
            for (int i = 0; i < wordParts.Count; i++)
            {
                var wordPart = wordParts[i];

                var block = Instantiate(_itemPrefab);
                block.Init(wordPart, _container, _dragLayer);

                _container.AddItem(block, Vector2.zero);
            }
        }
    }
}
