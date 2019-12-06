using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIController crystalUIPrefab;

    [SerializeField]
    private CatchingCrystalInfo catchCrystalUIPrefab;

    public CrystalUIController CrystalUIPrefab { get => crystalUIPrefab; }
    public CatchingCrystalInfo CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
