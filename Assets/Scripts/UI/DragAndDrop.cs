using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField]
        private Canvas canvas;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private ItemSlot itemSlot;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        internal void SetToSlot(ItemSlot slot)
        {
            itemSlot = slot;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition = itemSlot.rectTransform.anchoredPosition;
            canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

    }
}

