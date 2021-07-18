using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class FloatVariableToLetter : MonoBehaviour
{
    public FloatVariable variable;
    public TextMeshProUGUI text;
    public List<string> letters;
    private void Start()
    {
        if (!text)
        {
            text.GetComponent<TextMeshProUGUI>();
        }
    }
    public void SetText(float var)
    {
        variable.SetVariable(var);
        text.text = "" + letters[(int)variable.Value];
    }

}
