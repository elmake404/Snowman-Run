using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherData : MonoBehaviour
{
    [SerializeField]
    private Transform _modellesSpher;
    [SerializeField]
    private SpherMove _spherMove;public SpherMove Move 
    { get { return _spherMove; } }
    public float Radius 
    
    { get { return _modellesSpher.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;
    private void Start()
    {
        _modellesSpher.SetParent(null);
    }
}
