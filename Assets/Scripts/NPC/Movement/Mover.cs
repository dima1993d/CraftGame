using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AI_Mover : MonoBehaviour
{
    [SerializeField] private Transform _fightPlace;
    [SerializeField] private Transform _idlePlace;
    private Rigidbody _rb;
    private float _lerpValue = 0f;

    //[SerializeField] private GameObject _worker;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_lerpValue > 1) 
            return;

        _lerpValue += Time.deltaTime / 4;
        _rb.transform.position = Vector3.Lerp(_fightPlace.position, _idlePlace.position, _lerpValue);
    }
}
