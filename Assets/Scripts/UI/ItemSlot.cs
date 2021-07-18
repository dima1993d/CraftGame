using CraftGame.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace CraftGame.UI
{
    [System.Serializable]
    public class ItemSlot : MonoBehaviour, IPointerDownHandler
    {
        public RectTransform rectTransform;
        public IItem item;
        public int number;
        public IItemReference currentDragedItem;
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Left Mouse Button Clicked on: ", gameObject);
                if (currentDragedItem.item == null && item != null) //Get Item
                {
                    currentDragedItem.item = item;
                    currentDragedItem.number = number;
                    item = null;
                    number = 0;
                    return;
                }
                if (currentDragedItem.item != null && item == null) //Set Item
                {
                    item = currentDragedItem.item;
                    number = currentDragedItem.number;
                    currentDragedItem.item = null;
                    currentDragedItem.number = 0;
                    return;
                }
                if (currentDragedItem.item != null && item != null && currentDragedItem.item != item) //Swap Items
                {
                    IItem tempItem = item;
                    int tempNumber = number;

                    item = currentDragedItem.item;
                    number = currentDragedItem.number;

                    currentDragedItem.item = tempItem;
                    currentDragedItem.number = tempNumber;
                    return;
                }
                
            }
            
        
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Right Mouse Button Clicked on: ", gameObject);
                if (currentDragedItem.item != null)
                {
                    if (item == null)
                    {
                        item = currentDragedItem.item;
                        number = 1;
                        currentDragedItem.number--;
                        if (currentDragedItem.number == 0)
                        {
                            currentDragedItem.item = null;
                        }
                        return;
                    }
                    if (item == currentDragedItem.item)
                    {
                        number++;
                        currentDragedItem.number--;
                        if (currentDragedItem.number == 0)
                        {
                            currentDragedItem.item = null;
                        }
                        return;
                    }
                }
                if (currentDragedItem.item == null)
                {
                    if (item != null)
                    {
                        currentDragedItem.item = item;
                        if (number % 2 == 1)
                        {
                            number = (number - 1) / 2;
                            currentDragedItem.number = (number + 1) / 2;
                        }
                        else
                        {
                            number = currentDragedItem.number = number / 2;
                        }
                        return;
                    }
                }
                
            }
        }
    }
}

