using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AI_Mover : MonoBehaviour
{
    [SerializeField] private Transform _fightPlace;
    [SerializeField] private Transform _idlePlace;
    private Rigidbody rb;
    private float value;

    //[SerializeField] private GameObject _worker;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        value += Time.deltaTime / 3;
        rb.transform.position = Vector3.Lerp(_fightPlace.position, _idlePlace.position, value);

        if (value > 1) return;
    }
}
