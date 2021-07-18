using AssetIcons;
using UnityEngine;
using UnityEngine.UI;


namespace CraftGame.SO
{
    public abstract class IItem : ScriptableObject
    {
        public int number;
        [AssetIcon]
        public Sprite sprite;
    }

    public interface IBurnable
    {

    }
    public interface IMeltable
    {

    }
}
