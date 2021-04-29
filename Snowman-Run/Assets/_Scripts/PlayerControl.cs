using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector3 _startPosTouth, _currentPosTouth;
    private Camera _cam;
    private SpherData _spherData;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (TouchUtility.TouchCount>0)
        {
            Touch touch = TouchUtility.GetTouch(0);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                _startPosTouth =_cam.ScreenToViewportPoint( touch.position);
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out hit))
                {
                    _spherData = hit.collider.GetComponent<SpherData>();
                }
            }
            else if (touch.phase ==  TouchPhase.Moved)
            {
                _currentPosTouth = _cam.ScreenToViewportPoint(touch.position);

            }
        }
        else
        {
            if (_spherData != null)
            {
                if (Mathf.Abs(_currentPosTouth.x - _startPosTouth.x) > 0.05)
                {
                    _spherData.Move.MoveToAnotherRow((_currentPosTouth.x - _startPosTouth.x) > 0);
                }
            }

            _spherData = null;

        }
    }
}
