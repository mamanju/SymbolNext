using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUIPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private CrystalUIButton crystalUIPrefab;

    [SerializeField]
    private CatchingCrystal catchCrystalUIPrefab;

    public CrystalUIButton CrystalUIPrefab { get => crystalUIPrefab; }
    public CatchingCrystal CatchCrystalUIPrefab { get => catchCrystalUIPrefab; }
}
