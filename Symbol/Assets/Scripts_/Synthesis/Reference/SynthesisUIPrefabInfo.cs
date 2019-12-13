using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIController crystalUIPrefab;

    [SerializeField]
    private GameObject catchCrystalUIPrefab;

    public CrystalUIController CrystalUIPrefab { get => crystalUIPrefab; }
    public GameObject CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
