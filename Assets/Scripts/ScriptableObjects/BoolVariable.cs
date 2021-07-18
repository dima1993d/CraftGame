
using UnityEngine;
[CreateAssetMenu(fileName = "New BoolVariable", menuName = "BoolVariable", order = 51)]
public class BoolVariable : ScriptableObject
{
    public bool Value;

    public void SetValue(bool Value)
    {
        this.Value = Value;
    }

}
