using UnityEngine;
using UnityEngine.Events;

public class IntGameActionListenerCondition : MonoBehaviour, IGameActionListener<int>
{
    public IntGameAction GameAction;
    public MyIntEvent unityEvent;
    public int same;
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
        if (same == var)
        {

            unityEvent.Invoke(var);
        }
        
    }

    
}
