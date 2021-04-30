using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherMove : MonoBehaviour
{
    private SpherData _spherData;
    private TrafficInspector _trafficInspector;
    void Awake()
    {
        _spherData = GetComponent<SpherData>();
    }
    private void Start()
    {
        _trafficInspector = TrafficInspector.Instance;
    }

    void Update()
    {

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
