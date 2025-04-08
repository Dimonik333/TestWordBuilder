using System;

namespace WordBuilder
{
    [Serializable]
    public sealed class LevelCollection
    {
        public LevelData[] Levels;
    }

    [Serializable]
    public sealed class LevelData
    {
        public WordData[] Words;
    }

    [Serializable]
    public sealed class WordData
    {
        public string[] WordParts;

        public WordData(string[] wordParts)
        {
            WordParts = wordParts;
        }
    }
}