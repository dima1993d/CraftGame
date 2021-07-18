using UnityEngine;
using UnityEngine.Events;

public class IntGameActionListener : MonoBehaviour, IGameActionListener<int>
{
    public IntGameAction GameAction;
    public MyIntEvent unityEvent;

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

    public void OnEventRaized(int var)
    {
        unityEvent.Invoke(var);
    }

    
}
[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}