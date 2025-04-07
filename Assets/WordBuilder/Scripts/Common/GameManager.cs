using System.Linq;
using UnityEngine;

namespace WordBuilder
{
    public static class GameManager
    {
        private static int _levelIndex;
        private static LevelCollection _levelCollection = new();

        static GameManager()
        {
            _levelCollection = new LevelCollection()
            {
                Levels = new LevelData[]
                {
                    new()
                    {
                        Words = new WordData[]
                        {
                            new(new[]{ "ма", "ли", "на" }),
                            new(new[]{ "кар", "тон"}),
                            new(new[]{ "ма", "шина"}),
                            new(new[]{ "обл", "ако"})
                        }
                    },
                }
            };
        }

        public static int LevelsCount => _levelCollection.Levels.Length;

        public static int LevelIndex { get; }

        public static string[][] GetLevelData()
            => GetLevelData(_levelIndex);

        public static void CompleteLevel()
        {
            _levelIndex++;
            if (_levelIndex >= _levelCollection.Levels.Length)
                _levelIndex = 0;
        }

        public static void Load(LevelCollection levelCollection)
        {
            if (levelCollection != null)
                _levelCollection = levelCollection;
        }

        private static string[][] GetLevelData(int levelIndex)
        {
            Mathf.Clamp(levelIndex, 0, LevelsCount);
            var levelData = _levelCollection.Levels[levelIndex];
            var stringArray = levelData.Words.Select(word => word.WordParts).ToArray();
            return stringArray;
        }
    }
}