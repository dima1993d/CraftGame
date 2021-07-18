using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New String List Variable", menuName = "StringListVariable", order = 51)]
public class StringListVariable : ScriptableObject
{
    public List<string> Value;
}