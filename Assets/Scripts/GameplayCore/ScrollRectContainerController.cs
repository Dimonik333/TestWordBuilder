using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;


namespace WordBuilder
{
    public sealed class ScrollRectContainerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Vector3 _startPosition;
        private Vector3 _currentPosition;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private float _holdDistance;
        [SerializeField] private WordContainer _container;
        [SerializeField, Range(0, 1)] private float _dragSensitivity = 0.8f;
        
        private void Start()
        {
            EnableDraggables(false);
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _currentPosition = eventData.position;
            var distance = Vector3.Distance(_startPosition, _currentPosition);
            if (distance > _holdDistance)
            {
                var direction = _currentPosition - _startPosition;                
                if (Vector3.Dot(Vector3.up, direction.normalized) > 0.8)                
                    StartDrag(eventData);                
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _currentPosition = Vector3.zero;
            EnableDraggables(false);
        }

        private void StartDrag(PointerEventData eventData)
        {
            _scrollRect.StopMovement();

            ExecuteEvents.Execute(_scrollRect.viewport.gameObject, eventData, ExecuteEvents.pointerUpHandler);

            EnableDraggables(true);

            var raycastResults = ListPool<RaycastResult>.Get();

            EventSystem.current.RaycastAll(eventData, raycastResults);
            raycastResults.Sort((x, y) => x.depth.CompareTo(y.depth));

            foreach (var raycastResult in raycastResults)
            {
                if (!raycastResult.gameObject.TryGetComponent<WordBlock>(out var item))
                    continue;

                var inputModule = EventSystem.current.currentInputModule;

                FieldInfo pointerDataField = inputModule.GetType().GetField("m_PointerData", BindingFlags.Instance | BindingFlags.NonPublic);
                var m_PointerData = pointerDataField.GetValue(inputModule) as Dictionary<int, PointerEventData>;

                m_PointerData[PointerInputModule.kMouseLeftId].pointerPress = item.gameObject;
                m_PointerData[PointerInputModule.kMouseLeftId].pointerDrag = item.gameObject;
                
                ExecuteEvents.Execute(item.gameObject, eventData, ExecuteEvents.beginDragHandler);
                ExecuteEvents.Execute(item.gameObject, eventData, ExecuteEvents.pointerDownHandler);

                break;
            }
            ListPool<RaycastResult>.Release(raycastResults);
            EnableDraggables(false);
        }

        public void EnableDraggables(bool value)
        {
            _container.EnableItemsRaycast(value);
        }
    }
}
