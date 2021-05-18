using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField]
    private Transform PosSpher;
    private void OnTriggerEnter(Collider other)
    {
        var spher = other.GetComponent<SpherData>();
        if (spher != null && spher.IsRow && GameStage.IsGameFlowe)
        {
            GameStage.Instance.ChangeStage(Stage.WinGame);
            TrafficInspector.Instance.GoToTheHorn(PosSpher);
        }
    }
}
