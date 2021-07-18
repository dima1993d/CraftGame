using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntGameAction", menuName = "IntGameAction", order = 50)]
public class IntGameAction : GameAction<int>
{

    public void Trigger(int num)
    {
        InvokeAction(num);
    }
}

