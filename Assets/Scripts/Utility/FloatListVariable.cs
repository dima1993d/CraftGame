using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Float List Variable", menuName = "FloatListVariable", order = 51)]
public class FloatListVariable : ScriptableObject
{
    public List<float> Value;
}