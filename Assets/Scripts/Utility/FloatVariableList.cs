using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Float Variable List", menuName = "FloatVariableList", order = 51)]
public class FloatVariableList : ScriptableObject
{
    public List<FloatVariable> Value;
}