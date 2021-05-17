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
    private Spy _objSpher;
    [SerializeField]
    private ParticleSystem _steem;
    [SerializeField]
    private SphereCollider _colliderMain;
    [SerializeField]
    private ModelSpher _modelSpher;
    [SerializeField]
    private SphereLife _sphereLife;
    [SerializeField]
    private SpherMove _spherMove; public SpherMove Move
    { get { return _spherMove; } }

    [SerializeField]
    private MinMax _radiusData;
    private MassChanger _massChanger;
    public float Radius

    { get { return _objSpher.transform.localScale.x / 2; } }
    [HideInInspector]
    public int RowNumber;
    public bool IsRow
    { get { return TrafficInspector.Instance.ContainsRow(this) && TrafficInspector.Instance.RowIsOnTheGround(RowNumber); } }
    public void StoodInARow() => _objSpher.transform.SetParent(null);
    public void OffsetRecordModel() => _objSpher.OffsetRecord();
    private void OnTriggerStay(Collider other)
    {
        if (IsRow)
        {
            if(_massChanger==null)
                _massChanger = other.GetComponent<MassChanger>();
            if (_massChanger != null)
            {
                ChangeOfSize(_massChanger.AddedVolume);
                if(_massChanger.AddedVolume<0&&!_steem.isPlaying)
                {
                    _steem.Play();
                }
                _massChanger.Deform(this);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((_massChanger != null) && _massChanger.gameObject==other.gameObject)
        {
            _massChanger = null;
            _steem.Stop();
        }
    }
    private void ChangeOfSize(float addedSize)
    {
        _objSpher.transform.localScale += Vector3.one * addedSize;
        _colliderMain.radius = Radius;
        if (_objSpher.transform.localScale.x > _radiusData.Max)
        {
            _objSpher.transform.localScale = Vector3.one * _radiusData.Max;
        }
        else if (_objSpher.transform.localScale.x < _radiusData.Min)
        {
            _steem.transform.SetParent(null);
            _steem.Stop();

            _sphereLife.Death();
        }

        TrafficInspector.Instance.UpdateRowPosition(RowNumber);
    }
    //public void SelectionModel(int CountSpher, int IndexSpher) 
    //    => _modelSpher.SelectionModel(CountSpher, IndexSpher);
}
