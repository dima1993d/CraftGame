using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "New IntVariable", menuName = "IntVariable", order = 51)]
public class IntVariable : ScriptableObject
{
    public int Value;

    public void SetValue(int Value)
    {
        this.Value = Value;
    }
    public void SetValue(TextMeshProUGUI Value)
    {
        this.Value = int.Parse(Value.text);
    }
}
