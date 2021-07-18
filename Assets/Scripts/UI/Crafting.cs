using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI
{
    public class Crafting : SerializedMonoBehaviour
    {
        [BoxGroup("ItemSlot table")]
        [TableMatrix(SquareCells = true)]
        public ItemSlot[,] itemSlots = new ItemSlot[6,6];

        [BoxGroup("bool table")]
        [TableMatrix(SquareCells = true)]
        public bool[,] itemdSlots = new bool[6,6];
        public List<RecipeSO> recepy;

        [BoxGroup("Labled table")]
        [TableMatrix(HorizontalTitle = "X axis", VerticalTitle = "Y axis")]
        public GameObject[,] LabledTable = new GameObject[15, 10];

        [BoxGroup("Custom table")]
        [TableMatrix(DrawElementMethod = "DrawColoredEnumElement", ResizableColumns = false)]
        public bool[,] CustomCellDrawing = new bool[30, 30];

#if UNITY_EDITOR

        private static bool DrawColoredEnumElement(Rect rect, bool value)
        {
            if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
            {
                value = !value;
                GUI.changed = true;
                Event.current.Use();
            }

            UnityEditor.EditorGUI.DrawRect(rect.Padding(1), value ? new Color(0.1f, 0.8f, 0.2f) : new Color(0, 0, 0, 0.5f));

            return value;
        }

#endif
    }
}

