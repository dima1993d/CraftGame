using UnityEngine;
using UnityEngine.Events;

public class floatGameActionListener : MonoBehaviour, IGameActionListener<float>
{
    public FloatGameAction GameAction;
    public MyFloatEvent unityEvent;

    void OnEnable()
    {
        if (GameAction)
        {
            GameAction.RegisterListener(this);
        }
    }
    void OnDisable()
    {
        if (GameAction)
        {
            GameAction.UnRegisterListener(this);
        }
    }

    public void OnEventRaized(float var)
    {
        unityEvent.Invoke(var);
    }

    
}
[System.Serializable]
public class MyFloatEvent : UnityEvent<float>
{
}