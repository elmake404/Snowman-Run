using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherMove : MonoBehaviour
{
    private SpherData _spherData;
    private TrafficInspector _trafficInspector;
    [SerializeField]
    private Rigidbody _rbMain;
    void Awake()
    {
        _spherData = GetComponent<SpherData>();
    }
    private void Start()
    {
        _trafficInspector = TrafficInspector.Instance;
    }

    void FixedUpdate()
    {
        if (_rbMain.velocity.y>0)
        {
            _rbMain.velocity = Vector3.Slerp(_rbMain.velocity,Vector3.zero,0.5f);
        }
    }
    public void MoveToAnotherRow(bool right)
    {
        int row = right ? 1 : -1;
        row += _spherData.RowNumber;
        if (_trafficInspector.CheckRow(row))
        {
            Vector3 posSpher = TrafficInspector.Instance.GetLocalPositionInRow(row, _spherData.Radius);
            TrafficInspector.Instance.AddSpherDats(row, _spherData);
            transform.localPosition = posSpher;
        }
    }
}
