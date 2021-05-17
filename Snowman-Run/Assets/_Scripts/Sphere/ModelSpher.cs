using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpher : MonoBehaviour
{
    //[System.Serializable]
    //public struct ModelSelection
    //{
    //    public List<GameObject> Models;
    //}

    [SerializeField]
    private SpherData _spherData;
    //[SerializeField]
    //private List<ModelSelection> _modelСhoices;
    [SerializeField]
    private List<Material> _materials;
    [SerializeField]
    private GameObject _inactiveModel;
    [SerializeField]
    private MeshRenderer _activeModel;

    [SerializeField]
    private float _speedRotation;
    private void Start()
    {
        _inactiveModel.SetActive(true);
        _activeModel.material = _materials[Random.Range(0,_materials.Count)];

        //if (_activeModel == null)
        //{
        //    _activeSphere = _modelСhoices[0].Models[0];
        //    _activeSphere.SetActive(true);
        //}
    }
    private void FixedUpdate()
    {
        if (_spherData.IsRow)
        {
            int x = TrafficInspector.Instance.GetIndexSpher(_spherData.RowNumber, _spherData) % 2 == 0 ? 1 : -1;
            transform.Rotate(Vector3.right * x * _speedRotation);
        }
    }
    private void LateUpdate()
    {
        if (!_spherData.IsRow)
        {
            if (!_inactiveModel.activeSelf)
            {
                _inactiveModel.SetActive(true);
                _activeModel.gameObject.SetActive(false);
            }
        }
        else
        {
            if (_inactiveModel.activeSelf)
            {
                _inactiveModel.SetActive(false);
                _activeModel.gameObject.SetActive(true);
            }
        }

    }
    //void OnValidate()
    //{
    //    if (_modelСhoices.Count > 0)
    //    {
    //        for (int i = 0; i < _modelСhoices.Count; i++)
    //        {
    //            while (true)
    //            {
    //                if (_modelСhoices[i].Models.Count > i + 1)
    //                {
    //                    _modelСhoices[i].Models.RemoveAt(_modelСhoices[i].Models.Count - 1);
    //                }
    //                else if (_modelСhoices[i].Models.Count < i + 1)
    //                {
    //                    _modelСhoices[i].Models.Add(null);
    //                }
    //                else break;
    //            }
    //        }
    //    }
    //}
    //public void SelectionModel(int CountSpher, int IndexSpher)
    //{
    //    if (CountSpher >= _modelСhoices.Count) CountSpher = _modelСhoices.Count - 1;
    //    if (IndexSpher >= _modelСhoices[CountSpher].Models.Count) IndexSpher = 1;

    //    if (_activeSphere != null) _activeSphere.SetActive(false);

    //    _activeSphere = _modelСhoices[CountSpher].Models[IndexSpher];
    //    _activeSphere.SetActive(true);
    //}
}
