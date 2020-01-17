using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIManagement crystalUIPrefab;

    [SerializeField]
    private GameObject catchCrystalUIPrefab;

    public CrystalUIManagement CrystalUIPrefab { get => crystalUIPrefab; }
    public GameObject CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
