using UnityEngine;


namespace CraftGame.SO
{
    [CreateAssetMenu(fileName = "Fuel", menuName = "ScriptableObjects/FuelSO", order = 1)]
    public class FuelSO : IItem
    {
        public float burnTime;

    }
}

