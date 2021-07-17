using System.Collections;
using System.Collections.Generic;
using TMPro;
using SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_Manager : MonoBehaviour
    {
        private Inventory inventory;
        private SavedData savedData;
        public GameObject ItemPrefab;
        public GameObject Container;

        void Awake()
        {
            string data = SaveLoadSystem.Load();
            if (data == null)
            {
                savedData = new SavedData();
                inventory = new Inventory();
                savedData.inventory = inventory;
            }
            else
            {
                savedData = JsonUtility.FromJson<SavedData>(data);
                inventory = savedData.inventory;
            }          
        }
        private void OnApplicationQuit()
        {
            SaveLoadSystem.Save(JsonUtility.ToJson(savedData));
        }
        private void Start()
        {
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            foreach (var item in inventory.GetItems())
            {
                GameObject ItemInstance = Instantiate(ItemPrefab, Container.transform);
                ItemInstance.GetComponent<Image>().sprite = item.sprite;
                ItemInstance.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = "" + item.number;
            }
        }
    }

    public class SavedData
    {
        public Inventory inventory;

    }

}

