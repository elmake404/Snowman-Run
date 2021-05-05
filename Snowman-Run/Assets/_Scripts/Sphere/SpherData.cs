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
    public delegate void emptyMethod();
    public event emptyMethod Died;

    [SerializeField]
    private Spy _modellesSpher;
    [SerializeField]
    private SphereCollider _colliderMain;
    [SerializeField]
    private SpherMove _spherMove;public SpherMove Move 
    { get { return _spherMove; } }
    [SerializeField]
    private MinMax _radiusData;
    public float Radius 
    
    { get { return _modellesSpher.transform.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;

    public void StoodInARow()=> _modellesSpher.transform.SetParent(null);
    public void OffsetRecordModel() => _modellesSpher.OffsetRecord();
    private void OnCollisionEnter(Collision collision)
    {
        SpherData spher = TrafficInspector.Instance.ContainsAdditionalSphere(collision.gameObject);
        if (spher != null)
        {
            spher.StoodInARow();

            TrafficInspector.Instance.AddNewSpher(RowNumber, spher);
            spher.OffsetRecordModel();
            TrafficInspector.Instance.RemoveAdditionalSphere(spher);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        var Changer = other.GetComponent<MassChanger>();
        if (Changer!=null)
        {
            ChangeOfSize(Changer.AddedVolume);
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
            Death();
        }
        TrafficInspector.Instance.UpdateRowPosition(RowNumber);
    }
    private void Death()
    {
        TrafficInspector.Instance.RemoveSpher(RowNumber, this);
        Died?.Invoke();
        Destroy(gameObject);
    }
}
