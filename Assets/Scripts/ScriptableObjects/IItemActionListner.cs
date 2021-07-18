using UnityEngine;
using CraftGame.SO;
using UnityEngine.Events;

public class IItemActionListner : MonoBehaviour, IGameActionListener<IItem>
{
    [SerializeField]
    private IItemGameAction itemGameAction;
    public MyIItemEvent myIItemEvent;


    void OnEnable()
    {
        if (itemGameAction)
        {
            itemGameAction.RegisterListener(this);
        }
    }
    void OnDisable()
    {
        if (itemGameAction)
        {
            itemGameAction.UnRegisterListener(this);
        }
    }

    public void OnEventRaized(IItem var)
    {
        myIItemEvent.Invoke(var);
    }
}
[System.Serializable]
public class MyIItemEvent : UnityEvent<IItem>
{
}
