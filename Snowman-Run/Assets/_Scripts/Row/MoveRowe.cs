using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRowe : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameStage.IsGameFlowe)
        transform.Translate(Vector3.forward*_speed);
    }
}
