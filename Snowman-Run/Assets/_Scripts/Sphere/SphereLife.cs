using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLife : MonoBehaviour
{
    [SerializeField]
    private SpherData _spherData;
    private void OnTriggerEnter(Collider other)
    {
        SpherData spher = TrafficInspector.Instance.ContainsAdditionalSphere(other.gameObject);
        if (spher !=null)
        {
            spher.StoodInARow();

            TrafficInspector.Instance.AddNewSpher(_spherData.RowNumber, spher);
            spher.OffsetRecordModel();
            TrafficInspector.Instance.RemoveAdditionalSphere(spher);
        }
    }
}
