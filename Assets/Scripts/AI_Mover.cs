using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AI_Mover : MonoBehaviour
{
    [SerializeField] private Transform _fightPlace;
    [SerializeField] private Transform _idlePlace;
    private float value;

    //[SerializeField] private GameObject _worker;

    private void Update()
    {
        value += 0.001f;
        GetComponent<Rigidbody>().transform.position = Vector3.Lerp(_fightPlace.position, _idlePlace.position, value);

        if (value > 1) return;
    }
}
