using UnityEngine;

[CreateAssetMenu(fileName = "Ore", menuName = "ScriptableObjects/OreScriptableObject", order = 1)]
public class OreSO : IItem, IMeltable
{
    public IngredientSO meltsInTo;

}
