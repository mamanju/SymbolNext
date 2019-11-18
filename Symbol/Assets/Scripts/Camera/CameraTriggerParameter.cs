using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/MoveParameter", fileName = "MoveParameter")]
public class CameraTriggerParameter : ScriptableObject
{
    [SerializeField] private Vector3 sf_setOffSet = Vector3.zero;
    [SerializeField] private float sf_setMaxDistance = 0;
    
    public Vector3 MemoryOffSet { get; set; }
    public Vector3 SetOffSet { get => sf_setOffSet; }
    public float SetMaxDistance { get => sf_setMaxDistance; }
}
