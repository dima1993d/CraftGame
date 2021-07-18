
using CraftGame.SO;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CraftGame.UI
{
    [Obsolete]
    public class DragAndDrop : MonoBehaviour//, IPointerDownHandler//, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        /*
        [SerializeField]
        private Canvas canvas;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private IItem item;


        public IItemReference currentDragedItem;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        */
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

        

    }
}

