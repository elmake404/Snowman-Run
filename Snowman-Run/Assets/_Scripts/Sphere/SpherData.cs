using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MinMax
{
    public float Min;
    public float Max;
}
public class SpherData : MonoBehaviour
{
    [SerializeField]
    private Spy _modellesSpher;
    [SerializeField]
    private SphereCollider _colliderMain;
    [SerializeField]
    private SphereLife _sphereLife;
    [SerializeField]
    private SpherMove _spherMove; public SpherMove Move
    { get { return _spherMove; } }

    [SerializeField]
    private MinMax _radiusData;
    public float Radius 
    
    { get { return _modellesSpher.transform.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;
    public bool IsRow 
    { get { return !TrafficInspector.Instance.ContainsAdditionalSphere(this); } }

    public void StoodInARow()=> _modellesSpher.transform.SetParent(null);
    public void OffsetRecordModel() => _modellesSpher.OffsetRecord();
    private void OnTriggerStay(Collider other)
    {
        if (IsRow)
        {
            var Changer = other.GetComponent<MassChanger>();
            if (Changer != null)
            {
                ChangeOfSize(Changer.AddedVolume);
            }
        }
    }
    private void ChangeOfSize(float addedSize)
    {
        _modellesSpher.transform.localScale += Vector3.one * addedSize;
        _colliderMain.radius = Radius;
        if (_modellesSpher.transform.localScale.x > _radiusData.Max)
        {
            _modellesSpher.transform.localScale = Vector3.one * _radiusData.Max;
        }
        else if (_modellesSpher.transform.localScale.x < _radiusData.Min)
        {
           _sphereLife.Death();
        }

        TrafficInspector.Instance.UpdateRowPosition(RowNumber);
    }
}
