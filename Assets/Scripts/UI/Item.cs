using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftGame.UI
{
    [Serializable]
    public class Item
    {
        [SerializeField]
        public enum ItemType
        {
            Log,
            Coal,
            CopperOre,
            IronOre,
            Diamond,

            Sword,
            Spear,
            Shield,

            Helmet,
            Brestplate,
            Legs,
            Boots
        }

        public ItemType itemType;
        public int number;
        public Sprite sprite;
    }
}

