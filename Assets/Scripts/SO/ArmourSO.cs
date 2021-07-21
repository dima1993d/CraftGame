using UnityEngine;

namespace CraftGame.SO
{

    //[CreateAssetMenu(fileName = "Helmet", menuName = "ScriptableObjects/ArmourSO", order = 1)]
    public class ArmourSO: IItem
    {
        public int points;
        public GameObject prefab;
        public int index;
    }
}

