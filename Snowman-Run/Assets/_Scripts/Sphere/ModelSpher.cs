using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpher : MonoBehaviour
{
    [System.Serializable]
    public struct ModelSelection
    {
        public List<GameObject> Models;
    }
    [SerializeField]
    private List<ModelSelection> _modelСhoices;
    private GameObject _activeSpher;
    void OnValidate()
    {
        if (_modelСhoices.Count > 0)
        {
            for (int i = 0; i < _modelСhoices.Count; i++)
            {
                while (true)
                {
                    if (_modelСhoices[i].Models.Count > i + 1)
                    {
                        _modelСhoices[i].Models.RemoveAt(_modelСhoices[i].Models.Count - 1);
                    }
                    else if (_modelСhoices[i].Models.Count < i + 1)
                    {
                        _modelСhoices[i].Models.Add(null);
                    }
                    else break;
                }
            }
        }
    }
    public void SelectionModel(int CountSpher,int IndexSpher)
    {
        if (CountSpher>=_modelСhoices.Count) CountSpher = _modelСhoices.Count - 1;
        if (IndexSpher >= _modelСhoices[CountSpher].Models.Count) IndexSpher = 1;
            
     if (_activeSpher!=null)   _activeSpher.SetActive(false);

        _activeSpher= _modelСhoices[CountSpher].Models[IndexSpher];
        _activeSpher.SetActive(true);
    }
}
