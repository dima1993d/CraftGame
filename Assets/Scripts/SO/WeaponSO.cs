using UnityEngine;

namespace CraftGame.SO
{

    //[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponSO", order = 1)]
    public class WeaponSO : IItem
    {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale = Vector3.one;
        public int points;
        public GameObject prefab;
        public int index;
    }
}



