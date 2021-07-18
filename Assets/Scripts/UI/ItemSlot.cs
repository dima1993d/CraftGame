using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace UI
{
    [System.Serializable]
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public RectTransform rectTransform;

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

    }
}

