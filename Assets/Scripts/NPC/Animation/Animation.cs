using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class Animation : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField] private float _walkSpeed = 0.1f;

    private Animator _animator;
    private Rigidbody _rb;

    //To check for changing _currentState
    //private bool IsAtForge => transform.position == _idleTransformPoint.position;
    //private bool IsWalking => !IsAtForge;

    //Animation states
    const string IDLE = "Idle";
    const string WALKING = "Walking";

    // bool to send an NPC to fight 
    public bool Trigger = Input.GetMouseButtonDown(0);
    //default
    private string _currentState = WALKING;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
            return;

        _animator.SetTrigger(newState);
        _currentState = newState;
    }

    public void SetDestination(Transform to)
    {

    }

    private  void Update()
    {
        if (Vector3.Distance(transform.position, _to.position) > 0.1F)
        {
            transform.LookAt(_to);
            ChangeAnimationState(WALKING);

            _rb.MovePosition((transform.position - _to.position) * _walkSpeed * Time.deltaTime);
        }
        else
        {
            _rb.MovePosition(_to.position);
            ChangeAnimationState(IDLE);
        }
    }


}
