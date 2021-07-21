using CraftGame.SO;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "New IItemGameAction", menuName = "IItemGameAction", order = 50)]
public class IItemGameAction : GameAction<IItem>
{

    public void Trigger(IItem num)
    {
        InvokeAction(num);
    }
}

