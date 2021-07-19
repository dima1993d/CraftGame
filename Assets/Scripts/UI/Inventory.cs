using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CraftGame.SO;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace CraftGame.UI
{
    public class Inventory : SerializedMonoBehaviour
    {
        public Transform CraftingSlotsParent;

        [BoxGroup("ItemSlot table")]
        [TableMatrix(DrawElementMethod = "DrawColoredEnumElement", SquareCells = true)]
        public ItemSlot[,] itemSlots = new ItemSlot[9, 3];

        [Button]
        public void SetupSlots()
        {
            itemSlots = new ItemSlot[9, 3];
            int index = 0;
            for (int x = 0; x < itemSlots.GetLength(1); x++)
            {
                for (int y = 0; y < itemSlots.GetLength(0); y++)
                {
                    itemSlots[y, x] = CraftingSlotsParent.GetChild(index).GetComponent<ItemSlot>();
                    index++;
                }
            }
        }

#if UNITY_EDITOR

        private static ItemSlot DrawColoredEnumElement(Rect rect, ItemSlot value)
        {
            value = (ItemSlot)UnityEditor.EditorGUI.ObjectField(rect, value, typeof(ItemSlot), true);

            if (value.item != null)
            {
                if (value.item.sprite != null)
                {
                    UnityEditor.EditorGUI.DrawPreviewTexture(rect.Padding(1), value.item.sprite.texture);
                }
            }
            return value;
        }


#endif

        public void AddItem(IItem item, int amount)
        {
            for (int x = 0; x < itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < itemSlots.GetLength(1); y++)
                {
                    if (itemSlots[x, y].item == null)
                    {
                        itemSlots[x, y].item = item;
                        itemSlots[x, y].number = amount;
                        itemSlots[x, y].UpdateItemSlot();
                        return;
                    }
                }
            }


        }

    }
}

