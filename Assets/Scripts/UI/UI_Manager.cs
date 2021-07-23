using System.Collections;
using System.Collections.Generic;
using TMPro;
using CraftGame.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using CraftGame.SO;
using System;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

namespace CraftGame.UI
{
    public class UI_Manager : MonoBehaviour
    {
        public Inventory inventory;
        [SerializeField]
        public SavedData savedData = new SavedData();
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

        void Start()
        {
            string data = SaveLoadSystem.Load();
            if (data == null)
            {
                inventory.AddItem(Wood,10);
            }
            else
            {
                savedData = JsonUtility.FromJson<SavedData>(data);
                UnpackData(crafting.itemSlots, inventory.itemSlots, savedData);
            }
            DragedItemImage = DraggedItem.GetComponent<Image>();
            DragedItemNumber = DraggedItem.GetChild(0).GetComponent<TextMeshProUGUI>();

            RefreshInventory();
        }

        private ItemSlot[,] UnpackData(ItemSlot[,] craftingSlots, ItemSlot[,] inventorySlots, SavedData data)
        {
            for (int x = 0; x < craftingSlots.GetLength(0); x++)
            {
                for (int y = 0; y < craftingSlots.GetLength(1); y++)
                {
                    craftingSlots[x, y].UpdateItemSlot(allItems[data.crafting[x].craftinglist[y].ItemID], data.crafting[x].craftinglist[y].number);
                }
            }
            for (int x = 0; x < inventorySlots.GetLength(0); x++)
            {
                for (int y = 0; y < inventorySlots.GetLength(1); y++)
                {
                    inventorySlots[x, y].UpdateItemSlot(allItems[data.inventory[x].inventorylist[y].ItemID], data.inventory[x].inventorylist[y].number);
                }
            }
            return craftingSlots;
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
        [Button]
        private void Save()
        {
            savedData = SetupSavedData();
            SaveLoadSystem.Save(JsonUtility.ToJson(savedData));
        }

        private SavedData SetupSavedData()
        {
            SavedData temp = new SavedData();

            for (int x = 0; x < inventory.itemSlots.GetLength(0); x++)
            {
                temp.inventory.Add(new ItemDataList());
                for (int y = 0; y < inventory.itemSlots.GetLength(1); y++)
                {
                    temp.inventory[x].inventorylist.Add(new ItemData());
                    temp.inventory[x].inventorylist[y].ItemID = GetItemID(inventory.itemSlots[x, y]);
                    temp.inventory[x].inventorylist[y].number = inventory.itemSlots[x, y].number;
                }
            }
            for (int x = 0; x < crafting.itemSlots.GetLength(0); x++)
            {
                temp.crafting.Add(new ItemDataList());
                for (int y = 0; y < crafting.itemSlots.GetLength(1); y++)
                {
                    temp.crafting[x].craftinglist.Add(new ItemData());
                    temp.crafting[x].craftinglist[y].ItemID = GetItemID(crafting.itemSlots[x, y]);
                    temp.crafting[x].craftinglist[y].number = crafting.itemSlots[x, y].number;
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

        private void RefreshInventory()
        {
            for (int x = 0; x < inventory.itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < inventory.itemSlots.GetLength(1); y++)
                {
                    if (inventory.itemSlots[x, y].item != null)
                    {
                        inventory.itemSlots[x, y].UpdateItemSlot(inventory.itemSlots[x, y].item, inventory.itemSlots[x, y].number);
                    }                   
                }
            }
        }
    }
    [Serializable]
    public class SavedData
    {
        public List<ItemDataList> inventory = new List<ItemDataList>();
        public List<ItemDataList> crafting = new List<ItemDataList>();
        public List<ItemDataList> npc = new List<ItemDataList>();

    }
    [Serializable]
    public class ItemData
    {
        public int ItemID = 0;
        public int number = 0;
    }
    [Serializable]
    public class ItemDataList
    {
        public List<ItemData> inventorylist = new List<ItemData>();
        public List<ItemData> craftinglist = new List<ItemData>();
    }
}


