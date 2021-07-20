using UnityEngine;

namespace CraftGame.SO
{

    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponSO", order = 1)]
    public class WeaponSO : IItem
    {
        public enum WeaponSlot
        {
            sword,
            shield
        }
        public WeaponSlot type;
        public int points;
        public GameObject prefab;
    }
}



