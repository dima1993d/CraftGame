using System.Collections;
using System.Collections.Generic;
using TMPro;
using CraftGame.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using CraftGame.SO;
using System;
using UnityEngine.InputSystem;

namespace CraftGame.UI
{
    public class UI_Manager : MonoBehaviour
    {
        public Inventory inventory;
        private SavedData savedData = new SavedData();
        public GameObject ItemPrefab;
        public IItem Wood;
        public IItemReference currentDragedItem;
        public Crafting crafting;

        public RectTransform DraggedItem;
        private Image DragedItemImage;
        private TextMeshProUGUI DragedItemNumber;

        public List<IItem> allItems;

        private void Update()
        {
            if (currentDragedItem.item != null)
            {
                DraggedItem.gameObject.SetActive(true);
                DragedItemImage.sprite = currentDragedItem.item.sprite;
                DragedItemNumber.text = "" + currentDragedItem.number;
                DraggedItem.position = Mouse.current.position.ReadValue();
            }
            else
            {
                DraggedItem.gameObject.SetActive(false);
            }
            
        }

        void Awake()
        {
            string data = SaveLoadSystem.Load();
            if (data == null)
            {
                inventory.AddItem(Wood,10);
            }
            else
            {
                savedData = JsonUtility.FromJson<SavedData>(data);
                inventory.itemSlots = SetupItemData(inventory.itemSlots, savedData.inventory);
            }
            DragedItemImage = DraggedItem.GetComponent<Image>();
            DragedItemNumber = DraggedItem.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        private ItemSlot[,] SetupItemData(ItemSlot[,] itemSlots, ItemData[,] inventory)
        {
            for (int x = 0; x < itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < itemSlots.GetLength(1); y++)
                {
                    itemSlots[x, y].item = allItems[inventory[x,y].ItemID];
                    itemSlots[x, y].number = inventory[x,y].number;
                }
            }
            return itemSlots;
        }

        private void OnApplicationQuit()
        {
            Save();
        }
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                Save();
        }
        private void Save()
        {
            savedData = SetupSavedData();
            SaveLoadSystem.Save(JsonUtility.ToJson(savedData));
        }

        private SavedData SetupSavedData()
        {
            SavedData temp = new SavedData();
            temp.inventory = new ItemData[inventory.itemSlots.GetLength(0), inventory.itemSlots.GetLength(1)];
            temp.crafting = new ItemData[crafting.itemSlots.GetLength(0), crafting.itemSlots.GetLength(1)];


            for (int x = 0; x < inventory.itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < inventory.itemSlots.GetLength(1); y++)
                {
                    temp.inventory[x,y].ItemID = GetItemID(inventory.itemSlots[x, y]);
                }
            }
            
            for (int x = 0; x < crafting.itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < crafting.itemSlots.GetLength(1); y++)
                {
                    temp.crafting[x,y].ItemID = GetItemID(crafting.itemSlots[x, y]);
                }
            }

            return temp;
        }

        private int GetItemID(ItemSlot itemSlot)
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if (itemSlot.item == allItems[i])
                {
                    return i;
                }
            }
            return 0;
        }

        private void Start()
        {
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            for (int x = 0; x < inventory.itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < inventory.itemSlots.GetLength(1); y++)
                {
                    inventory.itemSlots[x, y].transform.GetChild(0).gameObject.SetActive(true);
                    inventory.itemSlots[x, y].transform.GetChild(0).GetComponent<Image>().sprite = inventory.itemSlots[x, y].item.sprite;
                    inventory.itemSlots[x, y].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + inventory.itemSlots[x, y].number;
                }
            }
        }
    }

    public class SavedData
    {
        public ItemData[,] inventory;
        public ItemData[,] crafting;
    }
    public class ItemData
    {
        public int ItemID = 0;
        public int number = 0;
    }
}


