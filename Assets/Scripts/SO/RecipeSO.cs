using Sirenix.OdinInspector;
using UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/RecipeScriptableObject", order = 1)]
public class RecipeSO : SerializedScriptableObject
{
    [TableMatrix(SquareCells = true)]
    public IItem[,] recipe = new IItem[6, 6];

}
