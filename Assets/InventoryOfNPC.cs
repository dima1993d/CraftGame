using CraftGame.SO;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOfNPC : MonoBehaviour
{
    public List<Transform> bones = new List<Transform>();
    public GameObject[] itemPrefabInstances = new GameObject[6];
    public ArmourSO[] armours = new ArmourSO[4];
    public WeaponSO[] weapons = new WeaponSO[2];
    public int strength = 0;
    public int currentTimeInTheDungeon = 0;
    public bool inDungeon = false;
    public void SpawnWeapon(IItem item)
    {
        WeaponSO weapon = (WeaponSO)item;
        if (weapon && weapon.prefab)
        {
            weapons[weapon.index] = weapon;
            SpawnItem(weapon.index + 4, weapon.prefab, weapon.pos, weapon.rot, weapon.scale);
        }
        
    }
    public void SpawnArmour(IItem item)
    {
        ArmourSO armour = (ArmourSO)item;
        if (armour && armour.prefab)
        {
            armours[armour.index] = armour;
            SpawnItem(armour.index, armour.prefab, armour.pos, armour.rot, armour.scale);
        }
        
    }
    public void SpawnItem(int boneIndex, GameObject prefab, Vector3 pos, Vector3 rot, Vector3 scale)
    {
        if (itemPrefabInstances[boneIndex])
        {
            Destroy(itemPrefabInstances[boneIndex]);
        }
        itemPrefabInstances[boneIndex] = Instantiate(prefab, bones[boneIndex]);

        itemPrefabInstances[boneIndex].transform.localScale = scale;
        itemPrefabInstances[boneIndex].transform.localPosition = pos;
        itemPrefabInstances[boneIndex].transform.localEulerAngles = rot;
        UpdateStrength();
    }
    void UpdateStrength()
    {
        strength = 0;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i])
            {
                strength += weapons[i].points;
            }
        }
        for (int i = 0; i < weapons.Length; i++)
        {
            if (armours[i])
            {
                strength += armours[i].points;
            }
        }
        
    }
    
}
