using UnityEngine;

namespace CraftGame.SO
{

    [CreateAssetMenu(fileName = "Helmet", menuName = "ScriptableObjects/ArmourSO", order = 1)]
    public class ArmourSO: IItem
    {
        public enum ArmourSlot
        {
            helmet,
            chest,
            legs,
            feet
        }
        public ArmourSlot type;
        public int points;
        public GameObject prefab;
    }
}

