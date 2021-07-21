using CraftGame.SO;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOfNPC : MonoBehaviour
{
    public List<Transform> bones = new List<Transform>();
    public GameObject[] items = new GameObject[6];

    public void SpawnWeapon(IItem item)
    {
        WeaponSO weapon = (WeaponSO)item;
        SpawnItem(weapon.index, weapon.prefab);
    }
    public void SpawnArmour(IItem item)
    {
        ArmourSO armour = (ArmourSO)item;
        SpawnItem(armour.index, armour.prefab);
    }
    public void SpawnItem(int boneIndex, GameObject prefab)
    {
        if (items[boneIndex])
        {
            Destroy(items[boneIndex]);
        }
        items[boneIndex] = Instantiate(prefab,bones[boneIndex]);
    }

    
}
