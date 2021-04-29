using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speedOfMovementInARow = 50f;

    void LateUpdate()
    {
        Vector3 newPos = transform.position;
        newPos.z = _target.position.z;
        transform.SetPositionAndRotation(newPos, _target.rotation);
        MoveSpher();
    }
    private void MoveSpher()
    {
        Vector3 pos = transform.localPosition;

        if ((transform.position.y > _target.position.y||(Mathf.Abs(transform.position.y - _target.position.y) <= 0.01))
            && Mathf.Abs(transform.position.x - _target.position.x) > 0.01)
        {
            pos.x = _target.position.x;
        }
        else if (Mathf.Abs(transform.position.y - _target.position.y) > 0.01)
        {
            pos.y = _target.position.y;

        }
        transform.position = Vector3.MoveTowards(transform.position, pos, _speedOfMovementInARow * Time.deltaTime);
    }

}
