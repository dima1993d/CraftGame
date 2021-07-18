using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CraftGame.SO;

namespace CraftGame.UI
{
    [Serializable]
    public class Inventory
    {
        private List<IItem> items;

        public Inventory()
        {
            items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }

        }
        public List<IItem> GetItems()
        {
            return items;
        }
    }
}

