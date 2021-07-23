using UnityEngine;


namespace CraftGame.SO
{
    [CreateAssetMenu(fileName = "Ore", menuName = "ScriptableObjects/OreSO", order = 1)]
    public class OreSO : IItem
    {
        public IngredientSO meltsInTo;
        public int needTimeToMelt = 1;
    }
}

