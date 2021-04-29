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
            StartCoroutine(MoveSpher(posSpher));
        }
    }
    private IEnumerator MoveSpher(Vector3 posSpher)
    {
        int[] namber = posSpher.y > transform.localPosition.y ? new int[3] { 2, 1, 3 } : new int[3] { 1, 2, 3 };
        int i = 0;
        while (true)
        {
            if (namber[i] == 1)
            {
                Vector3 pos = transform.localPosition;
                pos.x = posSpher.x;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, 0.5f);
                if (Mathf.Abs(transform.localPosition.x - posSpher.x) < 0.01) i++;
            }
            else if (namber[i] == 2)
            {
                Vector3 pos = transform.localPosition;
                pos.y = posSpher.y;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, 0.5f);
                if (Mathf.Abs(transform.localPosition.y - posSpher.y) < 0.01) i++;

            }
            else if (namber[i] == 3)
            {
                Debug.Log(123);
                break;
            }

            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
