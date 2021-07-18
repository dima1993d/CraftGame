using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }

        }
        public List<Item> GetItems()
        {
            return items;
        }
    }
}

