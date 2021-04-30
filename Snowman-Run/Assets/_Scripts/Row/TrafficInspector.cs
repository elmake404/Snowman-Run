using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficInspector : MonoBehaviour
{
    public static TrafficInspector Instance;

    [SerializeField]
    private List<Row> _rows = new List<Row>();
    private List<SpherData> _additionalSphere = new List<SpherData>();

    private void Update()
    {
    }
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < _rows.Count; i++)
        {
            _rows[i].InitializationNumber(i);
        }
    }
    public void UpdateRowPosition(int Row) => _rows[Row].UpdateSpherPosition();
    public void AddNewSpher(int row, SpherData spherData)
    {
        Vector3 posSpher = GetLocalPositionInRow(row, spherData.Radius);
        AddSpherDats(row, spherData);
        spherData.transform.localPosition = posSpher;
    }

    public void AddSpherDats(int rowNumber, SpherData spher)
    {
        Transform parent = _rows[rowNumber].GetRowPrent();
        spher.transform.SetParent(parent);
        _rows[rowNumber].AddSpher(_rows[spher.RowNumber].GetHigherSpheres(spher));
    }
    public Vector3 GetLocalPositionInRow(int rowNumber, float radius) 
        => _rows[rowNumber].GetLocalPosition(radius);
    public Vector3 GetGlobalPositionRow(int rowNumber, float radius)
     => _rows[rowNumber].transform.TransformPoint(_rows[rowNumber].GetLocalPosition(radius));
    public void AddAdditionalSphere(SpherData sphere)
        => _additionalSphere.Add(sphere);
    public void RemoveAdditionalSphere(SpherData sphere)
    => _additionalSphere.Remove(sphere);
    public SpherData ContainsAdditionalSphere(GameObject sphere)
    {
        for (int i = 0; i < _additionalSphere.Count; i++)
        {
            if (_additionalSphere[i].gameObject==sphere)
            {
                return _additionalSphere[i];
            }
        }
        return null;
    }

    public bool CheckRow(int row)
    {
        return row >= 0 && row < _rows.Count;
    }
}
