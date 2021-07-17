using UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Ore", menuName = "ScriptableObjects/OreScriptableObject", order = 1)]
public class RecipeSO : ScriptableObject
{
    public ItemSlot[,] itemSlots = new ItemSlot[6, 6];
}
