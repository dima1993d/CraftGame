using UnityEngine;

namespace CraftGame.SO
{

    //[CreateAssetMenu(fileName = "Helmet", menuName = "ScriptableObjects/ArmourSO", order = 1)]
    public class ArmourSO: IItem
    {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale = Vector3.one;
        public int points;
        public GameObject prefab;
        public int index;
    }
}

