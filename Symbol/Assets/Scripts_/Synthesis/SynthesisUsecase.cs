using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SynthesisUIPrefabInfo))]
public class SynthesisUsecase : MonoBehaviour
{
    private SynthesisUIPrefabInfo synPrefabInfo;

    [SerializeField]
    private PlayerStatusManagement playerStatus;

    [SerializeField]
    private CrystalDataList CrystalDataList;

    public SynthesisUIPrefabInfo SynPrefabInfo { get => synPrefabInfo; }
    public PlayerStatusManagement PlayerStatus { get => playerStatus; }
    public CrystalDataList GetCrystalDataList { get => CrystalDataList; }

    private void Awake()
    {
        synPrefabInfo = GetComponent<SynthesisUIPrefabInfo>();
    }
}
