using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector3 _offset;
    [SerializeField]
    private float _speedOfMovementInARow = 50f;

    void LateUpdate()
    {
        if (transform.parent != _target)
        {
            Vector3 newPos = transform.position;
            newPos.z = _target.position.z-_offset.z;
            transform.SetPositionAndRotation(newPos, _target.rotation);
            MoveSpher();
        }
    }
    private void MoveSpher()
    {
        Vector3 pos = transform.localPosition;

        if ((transform.position.y > _target.position.y || (Mathf.Abs(transform.position.y - _target.position.y) <= 0.01))
            && Mathf.Abs(transform.position.x - _target.position.x) > 0.01)
        {
            pos.x = _target.position.x;
        }
        else if (Mathf.Abs(transform.position.y - _target.position.y) > 0.01)
        {
            pos.y = _target.position.y;
        }
        else
        {
            _offset = Vector3.MoveTowards(_offset, Vector3.zero, _speedOfMovementInARow * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, _speedOfMovementInARow * Time.deltaTime);
    }
    public void OffsetRecord()
    {
        transform.SetParent(null);
        _offset.z = (_target.position - transform.position).z;
    }
}
