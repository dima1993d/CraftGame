using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class Animation : MonoBehaviour
{
    public Transform _to;
    public Transform _Player;
    [SerializeField] private float _walkSpeed = 0.1f;

    private Animator _animator;
    private Rigidbody _rb;

    //To check for changing _currentState
    //private bool IsAtForge => transform.position == _idleTransformPoint.position;
    //private bool IsWalking => !IsAtForge;

    //Animation states
    public string IDLE = "Stop";
    public string WALKING = "Run";

    // bool to send an NPC to fight 
    public bool Trigger = Input.GetMouseButtonDown(0);
    //default
    private string _currentState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }

    private void ChangeAnimationState(string newState)
    {
        _animator.SetTrigger(newState);
    }

    public void SetDestination(Transform to)
    {

    }

    private  void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, _to.position));
        if (Vector3.Distance(transform.position, _to.position) < 0.1F)
        {
            //transform.LookAt(_to);
            Vector3 difference = _to.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            ChangeAnimationState(WALKING);

            _rb.MovePosition((transform.position - _to.position).normalized * _walkSpeed * Time.deltaTime);
        }
        else
        {
            _rb.MovePosition(_to.position);
            ChangeAnimationState(IDLE);

            Vector3 difference = _Player.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
    }


}
