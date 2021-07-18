using UnityEngine;
[CreateAssetMenu(fileName = "New ColorVariable", menuName = "ColorVariable", order = 51),System.Serializable]
public class ColorVariable : ScriptableObject
{
    [ColorUsage(true, true)]
    public Color Value;
}
