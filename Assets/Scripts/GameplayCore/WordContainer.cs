using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace WordBuilder
{
    public sealed class WordContainer : MonoBehaviour
    {
        [SerializeField] private List<WordBlock> _blocks = new();

        [SerializeField] private int _capacity;
        [SerializeField] private RectTransform _rectTransform;
        

        public void AddItem(WordBlock item, Vector2 position)
        {
            var localPosition = _rectTransform.InverseTransformPoint(position);
            var index = -1;
            for (int i = 0; i < _blocks.Count; i++)
            {
                var existBlock = _blocks[i];
                if (existBlock.RectTransform.localPosition.x >= localPosition.x)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0)
                index = _blocks.Count;

            item.RectTransform.SetParent(_rectTransform, false);
            item.RectTransform.SetSiblingIndex(index);
            _blocks.Insert(index, item);
        }

        public void RemoveItem(WordBlock item)
        {
            _blocks.Remove(item);
        }

        public Vector2 GetItemPosition(WordBlock item)
        {
            return item.RectTransform.anchoredPosition;
        }

        public bool HasSpace(int size)
        {
            if (_capacity < 0)
                return true;
            var currentCapacity = _blocks.Sum(i => i.Size) + size;
            return currentCapacity <= _capacity;
        }

        internal void EnableItemsRaycast(bool value)
        {
            foreach (var block in _blocks)
                block.EnableRaycastTarget(value);
        }

        public bool IsFilled
            => _capacity == _blocks.Sum(i => i.Size);

        public string Word =>
            string.Concat(_blocks.Select(i => i.WordPart));
    }
}
