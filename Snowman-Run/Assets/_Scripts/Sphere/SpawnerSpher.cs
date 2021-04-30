using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnSpherData
{
    public int Row, Count;
}
[System.Serializable]
public struct SpawnAdditionalSpherData
{
    public int Row;
    public float ZPosition;
}
public class SpawnerSpher : MonoBehaviour
{
    [SerializeField]
    private List<SpawnSpherData> _startSpawn;
    [SerializeField]
    private List<SpawnAdditionalSpherData> _additionalSphere;
    [SerializeField]
    private SpherData _spherDataPrefabs;
    [SerializeField]
    private TrafficInspector _trafficInspector;

    private bool f;
    private void Start()
    {
        Spawn();
        f = true;
    }
    private void Spawn()
    {
        for (int i = 0; i < _additionalSphere.Count; i++)
        {
            Vector3 positionSpher = _trafficInspector.GetGlobalPositionRow(_additionalSphere[i].Row, _spherDataPrefabs.Radius);
            positionSpher.z += _additionalSphere[i].ZPosition;

            SpherData spher = Instantiate(_spherDataPrefabs, positionSpher, Quaternion.identity);
            spher.RowNumber = _startSpawn[i].Row;
            _trafficInspector.AddAdditionalSphere(spher);
        }

        for (int i = 0; i < _startSpawn.Count; i++)
        {
            for (int j = 0; j < _startSpawn[i].Count; j++)
            {
                SpherData spher = Instantiate(_spherDataPrefabs, transform.position, Quaternion.identity);
                spher.RowNumber = _startSpawn[i].Row;
                _trafficInspector.AddNewSpher(_startSpawn[i].Row, spher);
                spher.StoodInARow();
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (!f)
        {
            Gizmos.color = Color.blue;
            if (_additionalSphere.Count > 0)
            {
                for (int i = 0; i < _additionalSphere.Count; i++)
                {
                    Vector3 positionSpher = _trafficInspector.GetGlobalPositionRow(_additionalSphere[i].Row, _spherDataPrefabs.Radius);
                    positionSpher.z += _additionalSphere[i].ZPosition;
                    Gizmos.DrawSphere(positionSpher, _spherDataPrefabs.Radius);
                }
            }
        }
    }
}
