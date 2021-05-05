using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLife : MonoBehaviour
{
    public delegate void emptyMethod();
    public event emptyMethod Died;

    [SerializeField]
    private SpherData _spherData;

    private void OnCollisionEnter(Collision collision)
    {
        SpherData spher = TrafficInspector.Instance.GetAdditionalSphere(collision.gameObject);
        if (spher != null)
        {
            spher.StoodInARow();

            TrafficInspector.Instance.AddNewSpher(_spherData.RowNumber, spher);
            spher.OffsetRecordModel();
            TrafficInspector.Instance.RemoveAdditionalSphere(spher);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Abyss")
        {
            Death();
        }
    }
    public void Death()
    {
        TrafficInspector.Instance.RemoveSpher(_spherData.RowNumber, _spherData);
        Died?.Invoke();
        Destroy(gameObject);
    }

}
