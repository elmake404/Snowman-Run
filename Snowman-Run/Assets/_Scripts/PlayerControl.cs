using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector3 _startPosTouth, _currentPosTouth;
    private Camera _cam;
    private SpherData _spherData;
    [SerializeField]
    private LayerMask _layerMask;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (GameStage.IsGameFlowe)
        {
            if (TouchUtility.TouchCount > 0)
            {
                Touch touch = TouchUtility.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _startPosTouth = _cam.ScreenToViewportPoint(touch.position);
                    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit[] hit = Physics.RaycastAll(ray);
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.gameObject.layer == 10)
                        {
                            _spherData = hit[i].collider.GetComponent<SpherData>();
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Moved)
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
}
