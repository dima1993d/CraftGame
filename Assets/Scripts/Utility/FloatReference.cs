using System;


[Serializable]
public class FloatReference 
{
    public bool useConstant = false;
    public float constantValue;
    public FloatVariable variable;

    public float Value
    {
        get {return useConstant ? constantValue : variable.Value; }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                variable.Value = value;
            }
        }
    }
}
[Serializable]
public class IntReference
{
    public bool useConstant = false;
    public int constantValue;
    public IntVariable variable;

    public int Value
    {
        get { return useConstant ? constantValue : variable.Value; }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                variable.Value = value;
            }
        }
    }
}
