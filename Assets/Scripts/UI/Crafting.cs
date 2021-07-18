using CraftGame.SO;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CraftGame.UI
{
    public class Crafting : SerializedMonoBehaviour
    {
        public Transform CraftingSlotsParent;

        [BoxGroup("ItemSlot table")]
        [TableMatrix(SquareCells = true)]
        public ItemSlot[,] itemSlots = new ItemSlot[6,6];
        public ItemSlot resultSlots;


        [ShowInInspector, DoNotDrawAsReference]
        [TableMatrix(DrawElementMethod = "DrawColoredEnumElement", SquareCells = true)]
        public IItem[,] CraftingWindow = new IItem[6, 6];
        public IItem result;
        //public int amount = 1;
        [Button]
        public void SetupSlots()
        {
            int index = 0;
            for (int x = 0; x < itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < itemSlots.GetLength(1); y++)
                {
                    itemSlots[x, y] = CraftingSlotsParent.GetChild(index).GetComponent<ItemSlot>();
                    index++;
                }
            }
        }

#if UNITY_EDITOR

        private static IItem DrawColoredEnumElement(Rect rect, IItem value)
        {
            value = (IItem)UnityEditor.EditorGUI.ObjectField(rect, value, typeof(IItem), false);

            if (value != null)
            {
                if (value.sprite != null)
                {
                    UnityEditor.EditorGUI.DrawPreviewTexture(rect.Padding(1), value.sprite.texture);
                }
            }
            return value;
        }


#endif
    }
}

