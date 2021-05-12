using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassChanger : MeshDeformation
{
    [SerializeField]
    private float _addedVolume;public float AddedVolume { get { return _addedVolume; } }
}
