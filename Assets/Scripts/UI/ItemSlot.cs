using CraftGame.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace CraftGame.UI
{
    [System.Serializable]
    public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler, IPointerClickHandler
    {
        public RectTransform rectTransform;
        public IItem item;
        public int number;
        public IItemReference currentDragedItem;
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().SetToSlot(this);
            }

        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (currentDragedItem != null)
            {
                //currentDragedItem.SetToSlot(this);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (currentDragedItem.item != null)
                {
                    item = currentDragedItem.item;
                }
                Debug.Log("Right Mouse Button Clicked");
            }
        }
    }
}

