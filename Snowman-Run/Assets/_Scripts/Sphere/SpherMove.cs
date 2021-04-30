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

            //StartCoroutine(MoveSpher(posSpher));
        }
    }
    //private IEnumerator MoveSpher(Vector3 posSpher)
    //{
    //    int[] namber = posSpher.y > transform.localPosition.y ? new int[3] { 2, 1, 3 } : new int[3] { 1, 2, 3 };
    //    int i = 0;
    //    while (true)
    //    {
    //        Vector3 pos = transform.localPosition;

    //        if (namber[i] == 1)
    //        {
    //            pos.x = posSpher.x;
    //            if (Mathf.Abs(transform.localPosition.x - posSpher.x) < 0.01) i++;
    //        }
    //        else if (namber[i] == 2)
    //        {
    //            pos.y = posSpher.y;
    //            if (Mathf.Abs(transform.localPosition.y - posSpher.y) < 0.01) i++;

    //        }
    //        else if (namber[i] == 3)
    //        {
    //            break;
    //        }
    //        transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, _speedOfMovementInARow);

    //        yield return new WaitForSeconds(Time.fixedDeltaTime);
    //    }
    //}
}
