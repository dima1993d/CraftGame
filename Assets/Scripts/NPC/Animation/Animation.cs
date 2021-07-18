using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class Animation : MonoBehaviour
{
    [SerializeField] private Transform _idleTransformPoint;
    [SerializeField] private Transform _fightTransformPoint;
    [SerializeField] private float _walkSpeed = 1f;

    private Animator _animator;
    private Rigidbody _rb;

    //To check for changing _currentState
    private bool IsAtForge => transform.position == _idleTransformPoint.position;
    private bool IsWalking => !IsAtForge;

    //Animation states
    const string IDLE = "Idle";
    const string WALKING = "Walking";

    // bool to send an NPC to fight 
    public bool Trigger = Input.GetMouseButtonDown(0);
    //default
    private string _currentState = WALKING;
    private float _lerpValue;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
            return;

        _animator.Play(newState);
        _currentState = newState;
    }

    private  void Update()
    {
        if (IsAtForge)
        {
            ChangeAnimationState(IDLE);
        }
        else if (Trigger)
        {
            transform.LookAt(_fightTransformPoint);
            ChangeAnimationState(WALKING);

            if (_lerpValue > 1)
                return;

            _rb.transform.position = Vector3.Lerp(_idleTransformPoint.position, _fightTransformPoint.position, _lerpValue += Time.deltaTime / 4);

        }
    }


}
