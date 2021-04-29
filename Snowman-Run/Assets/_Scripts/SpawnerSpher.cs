using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnSpherData
{
    public int Row, Count;
}
public class SpawnerSpher : MonoBehaviour
{
    [SerializeField]
    private List<SpawnSpherData> _startSpawn;
    [SerializeField]
    private SpherData _spherDataPrefabs;

    private void Start()
    {
        for (int i = 0; i < _startSpawn.Count; i++)
        {
            for (int j = 0; j < _startSpawn[i].Count; j++)
            {
                SpherData spher = Instantiate(_spherDataPrefabs, transform.position, Quaternion.identity);
                spher.RowNumber = _startSpawn[i].Row;
                AddNewSpher(_startSpawn[i].Row, spher);
            }
        }
    }
    private void AddNewSpher(int row, SpherData spherData)
    {
        Vector3 posSpher = TrafficInspector.Instance.GetLocalPositionInRow(row, spherData.Radius);
        TrafficInspector.Instance.AddSpherDats(row, spherData);
        spherData.transform.localPosition = posSpher;
    }

}
