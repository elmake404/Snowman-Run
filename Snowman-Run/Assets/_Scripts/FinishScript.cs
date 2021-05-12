using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var spher = other.GetComponent<SpherData>();
        if (spher!=null&&spher.IsRow)
        {
            GameStage.Instance.ChangeStage(Stage.WinGame);
        }
    }
}
