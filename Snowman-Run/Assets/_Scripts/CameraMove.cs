using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector3 _offset;
    private Vector3 _velocity;
    [SerializeField]
    private float _delay=0.2f;

    private void Start()
    {
        _offset = _target.position - transform.position;
    }
    private void FixedUpdate()
    {
        //if (GameStage.IsGameFlowe)
        //{
            transform.position = Vector3.SmoothDamp(transform.position,_target.position-_offset,ref _velocity,_delay);
        //}
    }
}
