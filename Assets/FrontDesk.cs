using CraftGame.SO;
using CraftGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDesk : MonoBehaviour
{
    public InventoryOfNPC currentNPC;
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    public void UpdateNPC()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item)
            {
                if (Types.Equals(itemSlots[i].item.GetType(),typeof(WeaponSO)))
                {
                    WeaponSO weapon = (WeaponSO)itemSlots[i].item;
                    //currentNPC.SpawnItem(i, weapon.prefab);
                }
                if (Types.Equals(itemSlots[i].item.GetType(), typeof(ArmourSO)))
                {
                    ArmourSO armour = (ArmourSO)itemSlots[i].item;
                    //currentNPC.SpawnItem(i, armour.prefab);
                }
            }
            
        }
    }
}
