using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField]
    private List<SpherData> _spherDatas = new List<SpherData>();

    public int RowNumber
    {
        get; private set;
    }
    public Transform GetRowPrent() => _spherDatas.Count > 0 ? _spherDatas[_spherDatas.Count - 1].transform : transform;
    public Vector3 GetLocalPosition(float radius)
    {
        if (_spherDatas.Count > 0)
        {
            Vector3 posSpher = transform.position;
            for (int i = 0; i < _spherDatas.Count; i++)
            {
                posSpher.y += _spherDatas[i].Radius * 2;
            }
            posSpher.y += radius;

            return _spherDatas[_spherDatas.Count - 1].transform.InverseTransformPoint(posSpher);
        }
        else
        {
            Vector3 posSpher = transform.position;
            posSpher.y += radius;

            return transform.InverseTransformPoint(posSpher);
        }
    }
    public void UpdateSpherPosition()
    {
        Vector3 posSpher = transform.position;
        Transform ParentSphere = transform;

        for (int i = 0; i < _spherDatas.Count; i++)
        {
            posSpher.y += _spherDatas[i].Radius;
            _spherDatas[i].transform.localPosition = ParentSphere.InverseTransformPoint(posSpher);
            ParentSphere = _spherDatas[i].transform;
            posSpher.y += _spherDatas[i].Radius;
        }
    }
    public void AddSpher(List<SpherData> spherDatas)
    {
        for (int i = 0; i < spherDatas.Count; i++)
        {
            spherDatas[i].RowNumber = RowNumber;
        }
        _spherDatas.AddRange(spherDatas);
    }
    public List<SpherData> GetHigherSpheres(SpherData spher)
    {
        List<SpherData> sphers = new List<SpherData>();
        //sphers.Add(spher);
        if (_spherDatas.Contains(spher))
        {
            int numberSpher = _spherDatas.IndexOf(spher);

            for (int i = numberSpher; i < _spherDatas.Count; i++)
            {
                sphers.Add(_spherDatas[i]);
            }
            _spherDatas.RemoveRange(numberSpher, _spherDatas.Count - numberSpher);
        }
        else
            sphers.Add(spher);

        return sphers;
    }
    public void InitializationNumber(int number) => RowNumber = number;
}
