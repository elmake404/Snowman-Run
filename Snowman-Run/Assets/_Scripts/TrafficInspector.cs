using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficInspector : MonoBehaviour
{
    public static TrafficInspector Instance;

    [SerializeField]
    private List<Row> _rows = new List<Row>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < _rows.Count; i++)
        {
            _rows[i].InitializationNumber(i);
        }
    }
    public void AddSpherDats(int rowNumber, SpherData spher)
    {
        Transform parent = _rows[rowNumber].GetRowPrent();
        spher.transform.SetParent(parent);
        _rows[rowNumber].AddSpher(_rows[spher.RowNumber].GetHigherSpheres(spher));
    }
    public Vector3 GetLocalPositionInRow(int rowNumber, float radius) 
        => _rows[rowNumber].GetLocalPosition(radius);
    public bool CheckRow(int row)
    {
        return row >= 0 && row < _rows.Count;
    }
}
