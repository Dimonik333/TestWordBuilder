using UnityEngine;


namespace WordBuilder
{
    public sealed class BlockResizer : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _width;
        [SerializeField] private float _offset;
        [SerializeField] private int _size;

        public void SetSize(int size)
        {
            _size = size;
            var width = _width * size + 10 * (size - 1);
            var sizeDelta = _rectTransform.sizeDelta;
            sizeDelta.x = width;
            _rectTransform.sizeDelta = sizeDelta;
        }

        public int Size => _size;
    }
}
