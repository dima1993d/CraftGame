using UnityEngine;
using UnityEngine.Events;

public class EventOnEnter : MonoBehaviour
{
    public UnityEvent enter,exit;
    public string _tag = "Player";
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == _tag)
        {
            enter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _tag)
        {
            exit.Invoke();
        }
    }
}
