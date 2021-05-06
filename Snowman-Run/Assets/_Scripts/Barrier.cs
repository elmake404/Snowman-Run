using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private float _speedRotation;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * _speedRotation);
    }
}
