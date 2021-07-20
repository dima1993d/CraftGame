using UnityEngine;
using UnityEngine.Events;

public class EventOnEnter : MonoBehaviour
{
    public UnityEvent enter,exit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            exit.Invoke();
        }
    }
}
