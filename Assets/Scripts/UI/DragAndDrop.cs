using CraftGame.SO;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CraftGame.UI
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IGameActionListener<IItem>//, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField]
        private Canvas canvas;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private ItemSlot itemSlot;
        [SerializeField]
        private IItemGameAction itemGameAction;

        void OnEnable()
        {
            if (itemGameAction)
            {
                itemGameAction.RegisterListener(this);
            }
        }
        void OnDisable()
        {
            if (itemGameAction)
            {
                itemGameAction.UnRegisterListener(this);
            }
        }

        public void OnEventRaized(IItem var)
        {
             
        }


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            itemGameAction.RegisterListener(this);
        }

        internal void SetToSlot(ItemSlot slot)
        {
            itemSlot = slot;
        }

        void Drop()
        {
            SetToSlot(itemSlot);
        }
        /*
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
        }*/

        public void OnPointerDown(PointerEventData eventData)
        {
            if (true)
            {
                canvasGroup.blocksRaycasts = false;
            }
        }

    }
}

