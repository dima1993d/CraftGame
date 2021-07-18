using UnityEngine;
using System.Collections.Generic;

public class FloatVariableToFloatVariables : MonoBehaviour
{
    public List<FloatVariable> variables;

    public void Setvariables(float var)
    {
        for (int i = 0; i < variables.Count; i++)
        {
            if ((int)var == i)
            {
                variables[i].Value = 1;
            }
            else
            {
                variables[i].Value = 0;
            }
        }
        
    }

}
