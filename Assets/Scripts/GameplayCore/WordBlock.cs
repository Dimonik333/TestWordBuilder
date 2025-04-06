using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;


namespace WordBuilder
{


    public sealed class WordBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector2 _containerPosition;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Graphic _raycastTarget;
        [SerializeField] private BlockResizer _resizer;
        [Space]
        [SerializeField] private string _wordPart;
        [SerializeField] private RectTransform _dragLayer;
        [SerializeField] private WordContainer _container;

        public RectTransform RectTransform => _rectTransform;
        public string WordPart => _wordPart;


        public void Init(string wordPart, WordContainer container, RectTransform dragLayer)
        {
            _label.text = wordPart;

            _wordPart = wordPart;
            _resizer.SetSize(_wordPart.Length);

            _container = container;
            _dragLayer = dragLayer;
        }

        public int Size => _resizer.Size;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _rectTransform.SetParent(_dragLayer, true);
            _containerPosition = _container.GetItemPosition(this);
            _container.RemoveItem(this);
            _rectTransform.SetParent(_dragLayer, true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.Translate(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (TryFindEmptyContainer(eventData, out var container))
            {
                _container = container;
                _container.AddItem(this, eventData.position);
            }
            else
                _container.AddItem(this, _containerPosition);
        }


        private bool TryFindEmptyContainer(PointerEventData eventData, out WordContainer container)
        {
            var result = false;
            container = null;

            var raycastResults = ListPool<RaycastResult>.Get();

            EventSystem.current.RaycastAll(eventData, raycastResults);
            raycastResults.Sort((x, y) => x.depth.CompareTo(y.depth));

            foreach (var raycastResult in raycastResults)
            {
                if (!raycastResult.gameObject.TryGetComponent(out container))
                    continue;
                if (!container.HasSpace(_resizer.Size))
                    continue;
                result = true;
                break;
            }

            ListPool<RaycastResult>.Release(raycastResults);

            return result;
        }

        public void EnableRaycastTarget(bool value)
        {
            _raycastTarget.raycastTarget = value;
        }
    }
}
