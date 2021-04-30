using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherData : MonoBehaviour
{
    [SerializeField]
    private Spy _modellesSpher;
    [SerializeField]
    private SpherMove _spherMove;public SpherMove Move 
    { get { return _spherMove; } }
    public float Radius 
    
    { get { return _modellesSpher.transform.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;
    public void StoodInARow()=> _modellesSpher.transform.SetParent(null);
    public void OffsetRecordModel() => _modellesSpher.OffsetRecord();
}
