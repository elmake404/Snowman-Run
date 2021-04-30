using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherData : MonoBehaviour
{
    [SerializeField]
    private Spy _modellesSpher;
    [SerializeField]
    private SphereCollider _colliderMain;
    [SerializeField]
    private SpherMove _spherMove;public SpherMove Move 
    { get { return _spherMove; } }
    public float Radius 
    
    { get { return _modellesSpher.transform.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;
    public void StoodInARow()=> _modellesSpher.transform.SetParent(null);
    public void OffsetRecordModel() => _modellesSpher.OffsetRecord();
    private void OnTriggerStay(Collider other)
    {
        var Changer = other.GetComponent<MassChanger>();
        if (Changer!=null)
        {
            _modellesSpher.transform.localScale += Vector3.one * Changer.AddedVolume;
            _colliderMain.radius = Radius;
            TrafficInspector.Instance.UpdateRowPosition(RowNumber);
        }
    }
}
