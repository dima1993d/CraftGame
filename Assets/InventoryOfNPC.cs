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
        if (weapon && weapon.prefab)
        {
            SpawnItem(weapon.index, weapon.prefab, weapon.pos, weapon.rot, weapon.scale);
        }
        
    }
    public void SpawnArmour(IItem item)
    {
        ArmourSO armour = (ArmourSO)item;
        if (armour && armour.prefab)
        {
            SpawnItem(armour.index, armour.prefab, armour.pos, armour.rot, armour.scale);
        }
        
    }
    public void SpawnItem(int boneIndex, GameObject prefab, Vector3 pos, Vector3 rot, Vector3 scale)
    {
        if (items[boneIndex])
        {
            Destroy(items[boneIndex]);
        }
        items[boneIndex] = Instantiate(prefab, bones[boneIndex]);

        items[boneIndex].transform.localScale = scale;
        items[boneIndex].transform.localPosition = pos;
        items[boneIndex].transform.localEulerAngles = rot;

    }

    
}
