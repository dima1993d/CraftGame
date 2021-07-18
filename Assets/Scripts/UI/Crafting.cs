using CraftGame.SO;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CraftGame.UI
{
    public class Crafting : SerializedMonoBehaviour
    {
        public Transform CraftingSlotsParent;

        [BoxGroup("ItemSlot table")]
        [TableMatrix(DrawElementMethod = "DrawColoredEnumElement",SquareCells = true)]
        public ItemSlot[,] itemSlots = new ItemSlot[6,6];
        public ItemSlot resultSlot;

        public List<RecipeSO> recipes;

        

        /*
        [ShowInInspector, DoNotDrawAsReference]
        [TableMatrix(DrawElementMethod = "DrawColoredEnumElement", SquareCells = true)]
        public IItem[,] CraftingWindow = new IItem[6, 6];
        public IItem result;

        [BoxGroup("ItemSlot table")]
        [TableMatrix(SquareCells = true)]
        public int[,] itemNumbers = new int[6, 6];
        public int resultNumber;
        */
        //public int amount = 1;

        public void Check()
        {
            bool same = false;
            int index = 0;
            IItem[,] CraftingWindow = GetCurrentItems();
            if (IsEmpty(CraftingWindow))
            {
                ClearResultSlot();
            }
            same = SimpleCheck(ref index, CraftingWindow);

            if (!same)
            {
                int[] smallestIndexs = GetSmallestIndexs(CraftingWindow);
                if (smallestIndexs[0] == 0 && smallestIndexs[1] == 0)
                {

                }
                else
                {
                    IItem[,] TempCraftingWindow = new IItem[6, 6];
                    for (int x = smallestIndexs[0]; x < CraftingWindow.GetLength(0); x++)
                    {
                        for (int y = smallestIndexs[1]; y < CraftingWindow.GetLength(1); y++)
                        {
                            if (CraftingWindow[x, y] != null)
                            {
                                TempCraftingWindow[x - smallestIndexs[0], y - smallestIndexs[1]] = CraftingWindow[x, y];
                            }
                        }
                    }
                    same = SimpleCheck(ref index, TempCraftingWindow);
                }
            }

            if (same)
            {
                resultSlot.item = recipes[index].result;
                resultSlot.number = recipes[index].amount;
            }
            if (!same)
            {
                ClearResultSlot();
            }

        }

        private int[] GetSmallestIndexs(IItem[,] craftingWindow)
        {
            int smallestX = 0, smallestY = 0;
            for (int x = 0; x < craftingWindow.GetLength(0); x++)
            {
                for (int y = 0; y < craftingWindow.GetLength(1); y++)
                {
                    if (craftingWindow[x, y] != null)
                    {
                        if (x< smallestX)
                        {
                            smallestX = x;
                        }
                        if (y < smallestY)
                        {
                            smallestY = y;
                        }
                    }
                }
            }


            return new int[2]{ smallestX, smallestY };
        }

        private void ClearResultSlot()
        {
            resultSlot.item = null;
            resultSlot.number = 0;
        }

        private bool IsEmpty(IItem[,] craftingWindow)
        {
            for (int x = 0; x < craftingWindow.GetLength(0); x++)
            {
                for (int y = 0; y < craftingWindow.GetLength(1); y++)
                {
                    if (craftingWindow[x,y] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool SimpleCheck(ref int index, IItem[,] CraftingWindow)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                if (ArraysAreTheSame(recipes[i].recipes, CraftingWindow))
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        [Button]
        public void SetupSlots()
        {
            itemSlots = new ItemSlot[6, 6];
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
        public IItem[,] GetCurrentItems()
        {
            IItem[,] CraftingWindow = new IItem[6, 6];
            for (int x = 0; x < itemSlots.GetLength(0); x++)
            {
                for (int y = 0; y < itemSlots.GetLength(1); y++)
                {
                    CraftingWindow[x, y] = itemSlots[x, y].item;
                }
            }
            return CraftingWindow;
        }
        bool ArraysAreTheSame(IItem[,] first, IItem[,] second)
        {
            if (first.GetLength(0) != second.GetLength(0)
                || first.GetLength(1) != second.GetLength(1))
            {
                return false;
            }
            for (int x = 0; x < first.GetLength(0); x++)
            {
                for (int y = 0; y < first.GetLength(1); y++)
                {
                    if (first[x, y] != second[x, y]) return false;
                }
            }
            return true;
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
    }
}

