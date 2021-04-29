using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    void LateUpdate()
    {
        transform.SetPositionAndRotation(_target.position,_target.rotation);
    }
}
