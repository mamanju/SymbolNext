using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIManagement crystalUIPrefab;

    [SerializeField]
    private CatchingCrystal catchCrystalUIPrefab;

    public CrystalUIManagement CrystalUIPrefab { get => crystalUIPrefab; }
    public CatchingCrystal CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
