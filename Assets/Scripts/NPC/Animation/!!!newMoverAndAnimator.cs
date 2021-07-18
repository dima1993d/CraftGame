using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMoverAndAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _npcPrefab;
    private Animator _animator;
    private Rigidbody  _rb;

    [SerializeField] private Transform  _spawnPoint; //fight point
    [SerializeField] private Transform _idlePoint;

    public void MakeMovement(GameObject npc, Transform from, Transform to, float step = 0.0005f)
    {
        if (step > 1)
            return;
        step += Time.deltaTime / 4f;
        npc.GetComponent<Rigidbody>().position = Vector3.Lerp(from.position, to.position, step);
    }

    private void Start()
    {
        GameObject newNpc = Instantiate(_npcPrefab, _spawnPoint.position, Quaternion.identity);
        newNpc.transform.LookAt(_idlePoint.position);

        _rb = newNpc.GetComponent<Rigidbody>();
        _animator = newNpc.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //MakeMovement(newNpc, _spawnPoint, _idlePoint);
    }
}

