using CraftGame.SO;
using System;
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
        public BoolGameAction UpdateUI;
        public SlotType slotType;
        public enum SlotType
        {
            IItem,
            ArmourSO,
            WeaponSO,
            OreSO
        }

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            itemIcon = transform.GetChild(0).GetComponent<Image>();
            itemNumberText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        }
        public void UpdateItemSlot(IItem item,int number)
        {
            UpdateItemSlot(item,number,true);
        }
        public void UpdateItemSlot(IItem item,int number,bool TriggerUpdateUI)
        {
            if (number <= 0)
            {
                this.item = null;
                this.number = 0;
            }
            else
            {
                this.item = item;
                this.number = number;
            }
            if (this.item)
            {
                itemIcon.gameObject.SetActive(true);
                itemIcon.sprite = item.sprite;
                itemNumberText.text = "" + number;
            }
            else
            {
                itemIcon.gameObject.SetActive(false);
            }
            if (TriggerUpdateUI)
            {
                UpdateUI?.InvokeAction(true);
            }
            
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            
            if (currentDragedItem.item != null && (int)slotType != 0)
            {
                string st = SlotType.GetName(typeof(SlotType), slotType);
                Type t2 = currentDragedItem.item.GetType();
                if (!t2.ToString().Contains(st))
                {
                    Debug.Log("" + st);
                    Debug.Log("" + t2.ToString());
                    return;
                }
            }
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                //Debug.Log("Left Mouse Button Clicked on: ", gameObject);
                if (currentDragedItem.item == null && item != null) //Get Item
                {
                    currentDragedItem.item = item;
                    currentDragedItem.number = number;
                    UpdateItemSlot(null,0);
                    return;
                }
                if (currentDragedItem.item != null && item == null) //Set Item
                {
                    UpdateItemSlot(currentDragedItem.item, currentDragedItem.number);
                    currentDragedItem.item = null;
                    currentDragedItem.number = 0;
                    return;
                }
                if (currentDragedItem.item != null && item != null && currentDragedItem.item == item) //Add Items
                {
                    UpdateItemSlot(item, number + currentDragedItem.number);
                    currentDragedItem.item = null;
                    currentDragedItem.number = 0;
                    return;
                }
                if (currentDragedItem.item != null && item != null && currentDragedItem.item != item) //Swap Items
                {
                    IItem tempItem = item;
                    int tempNumber = number;
                    UpdateItemSlot(currentDragedItem.item, currentDragedItem.number);

                    currentDragedItem.item = tempItem;
                    currentDragedItem.number = tempNumber;
                    return;
                }
                
            }
            
        
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                //Debug.Log("Right Mouse Button Clicked on: ", gameObject);
                if (currentDragedItem.item != null)
                {
                    if (item == null)
                    {
                        UpdateItemSlot(currentDragedItem.item,1);
                        currentDragedItem.number--;
                        if (currentDragedItem.number == 0)
                        {
                            currentDragedItem.item = null;
                        }
                        return;
                    }
                    if (item == currentDragedItem.item)
                    {
                        currentDragedItem.number--;
                        if (currentDragedItem.number == 0)
                        {
                            currentDragedItem.item = null;
                        }
                        UpdateItemSlot(item,number + 1);
                        return;
                    }
                }
                if (currentDragedItem.item == null)
                {
                    if (item != null)
                    {
                        currentDragedItem.item = item;
                        if (number == 1)
                        {
                            currentDragedItem.number = number;
                            UpdateItemSlot(null,0);
                            return;
                        }
                        int temp = number;
                        if (number % 2 == 1)
                        {
                            temp = (number - 1) / 2;
                            currentDragedItem.number = (number + 1) / 2;
                        }
                        else
                        {
                            currentDragedItem.number = number / 2;
                            temp = currentDragedItem.number;
                        }
                        UpdateItemSlot(item, temp);
                        return;
                    }
                }
                
            }
            
        }
    }
}

