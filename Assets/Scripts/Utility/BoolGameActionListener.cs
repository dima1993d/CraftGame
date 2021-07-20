using UnityEngine;
using UnityEngine.Events;

public class BoolGameActionListener : MonoBehaviour, IGameActionListener<bool>
{
    public BoolGameAction GameAction;
    public MyBoolEvent unityEvent;
    public bool inverce = false;
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

    public void OnEventRaized(bool var)
    {
        unityEvent.Invoke(inverce ? !var : var);
    }

    
}
[System.Serializable]
public class MyBoolEvent : UnityEvent<bool>
{
}