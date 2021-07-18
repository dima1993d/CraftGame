using UnityEngine;

namespace CraftGame.SO
{
    [CreateAssetMenu(fileName = "IItemReference", menuName = "ScriptableObjects/IItemReferenceScriptableObject", order = 1)]
    public class IItemReference : ScriptableObject
    {
        public IItem item;
        public int number;
    }

}
