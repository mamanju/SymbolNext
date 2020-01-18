using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIManagement crystalUIPrefab;

    [SerializeField]
    private CatcingCrystal catchCrystalUIPrefab;

    public CrystalUIManagement CrystalUIPrefab { get => crystalUIPrefab; }
    public CatcingCrystal CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
