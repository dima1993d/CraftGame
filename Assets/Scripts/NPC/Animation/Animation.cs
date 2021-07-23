using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class Animation : MonoBehaviour
{
    public Transform _to;
    public Transform _Player;
    [SerializeField] private float _walkSpeed = 20f;

    public Animator _animator;
    private Rigidbody _rb;

    //To check for changing _currentState
    //private bool IsAtForge => transform.position == _idleTransformPoint.position;
    //private bool IsWalking => !IsAtForge;

    //Animation states
    public string IDLE = "Stop";
    public string WALKING = "Run";

    // bool to send an NPC to fight 
    //public bool Trigger = Input.GetMouseButtonDown(0);
    //default
    private string _currentState;

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }

    public void ChangeAnimationState(string newState)
    {
        _animator.SetTrigger(newState);
    }

    public void SetDestination(Transform to)
    {

    }

    private  void Update()
    {
        
        if (Vector3.Distance(transform.position, _to.position) > 0.1F)
        {
            //Debug.Log(Vector3.Distance(transform.position, _to.position));
            //transform.LookAt(_to);
            Vector3 difference = _to.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0.0f, rotationZ, 0.0f);

            transform.LookAt(_to.position);
            transform.rotation = Quaternion.Euler(0.0f, transform.rotation.y + 180, 0.0f);
            //ChangeAnimationState(WALKING);
            //_rb.position();
            _rb.MovePosition(transform.position + ( _to.position - transform.position).normalized * _walkSpeed * Time.deltaTime);
        }
        else
        {
            //Debug.Log("gotto");
            _rb.MovePosition(_to.position);
            ChangeAnimationState(IDLE);

            Vector3 difference = _Player.position - _Player.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rotationZ - 90, 0.0f);
        }
    }


}
