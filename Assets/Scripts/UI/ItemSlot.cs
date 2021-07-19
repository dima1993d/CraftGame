using CraftGame.SO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CraftGame.UI
{
    [System.Serializable]
    public class ItemSlot : MonoBehaviour, IPointerDownHandler
    {
        public RectTransform rectTransform;
        public IItem item;
        public int number;
        public IItemReference currentDragedItem;
        public Image itemIcon;
        public TextMeshProUGUI itemNumberText;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            itemIcon = transform.GetChild(0).GetComponent<Image>();
            itemNumberText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        }
        public void UpdateItemSlot()
        {
            if (item)
            {
                itemIcon.gameObject.SetActive(true);
                itemIcon.sprite = item.sprite;
                itemNumberText.text = "" + number;
            }
            else
            {
                itemIcon.gameObject.SetActive(false);
            }
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
                    UpdateItemSlot();
                    return;
                }
                if (currentDragedItem.item != null && item == null) //Set Item
                {
                    item = currentDragedItem.item;
                    number = currentDragedItem.number;
                    currentDragedItem.item = null;
                    currentDragedItem.number = 0;
                    UpdateItemSlot();
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
                    UpdateItemSlot();
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
                        UpdateItemSlot();
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
                        UpdateItemSlot();
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
                        UpdateItemSlot();
                        return;
                    }
                }
                
            }
        }
    }
}

