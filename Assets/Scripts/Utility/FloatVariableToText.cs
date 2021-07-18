using UnityEngine;
using TMPro;

public class FloatVariableToText : MonoBehaviour
{
    public FloatVariable variable;
    public TextMeshProUGUI text;
    private void Start()
    {
        if (!text)
        {
            text.GetComponent<TextMeshProUGUI>();
        }
        SetText(variable.Value);
    }
    public void SetText(float var)
    {
        variable.SetVariable(var);
        text.text = "" + Mathf.Abs(variable.Value);
    }

}
