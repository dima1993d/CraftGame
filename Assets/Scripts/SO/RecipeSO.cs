using Sirenix.OdinInspector;
using Sirenix.Utilities;
using CraftGame.SO;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/RecipeScriptableObject", order = 1)]
public class RecipeSO : SerializedScriptableObject
{

    
    [ShowInInspector, DoNotDrawAsReference]
    [TableMatrix(DrawElementMethod = "DrawColoredEnumElement", SquareCells = true)]
    public IItem[,] recipes = new IItem[6, 6];

    public IItem result;
    public int amount = 1;

#if UNITY_EDITOR

    private static IItem DrawColoredEnumElement(Rect rect, IItem value)
    {
        value = (IItem)UnityEditor.EditorGUI.ObjectField(rect, value, typeof(IItem), false);

        if (value != null)
        {
            if (value.sprite != null)
            {
                UnityEditor.EditorGUI.DrawPreviewTexture(rect.Padding(1), value.sprite.texture);
            }
        }
        return value;
    }
    
   
#endif
}
