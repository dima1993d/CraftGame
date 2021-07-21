using AssetIcons;
using UnityEngine;
using UnityEngine.UI;


namespace CraftGame.SO
{
    public abstract class IItem : ScriptableObject
    {
        [AssetIcon]
        public Sprite sprite;
    }

}
