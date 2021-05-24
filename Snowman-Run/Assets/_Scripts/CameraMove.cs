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
    private Animator _animator;

    private bool _isFinish;
    [SerializeField]
    private float _delay = 0.2f;

    private void Start()
    {
        if (_animator != null)
            _animator.enabled = false;
        _offset = _target.position - transform.position;
    }
    private void FixedUpdate()
    {
        //if (!_isFinish)
        //{
        transform.position = Vector3.SmoothDamp(transform.position, _target.position - _offset, ref _velocity, _delay);
        //}
    }
    public void StartAnimation()
    {
        if (_animator != null)
        {
            _animator.enabled = true;
            _isFinish = true;
            _animator.SetBool("End", true);
        }
    }
}
