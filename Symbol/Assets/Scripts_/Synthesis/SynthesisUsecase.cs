using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisUsecase : MonoBehaviour
{
    //[SerializeField]
    private SynthesisController synController;
    //[SerializeField]
    private SynthesisManager synManager;
    //[SerializeField]
    private SynthesisUIController synUIController;
    //[SerializeField]
    private SynthesisUIPrefabInfo synPrefabInfo;

    public SynthesisController SynController { get => synController; }
    public SynthesisManager SynManager { get => synManager; }
    public SynthesisUIController SynUIController { get => synUIController; }
    public SynthesisUIPrefabInfo SynPrefabInfo { get => synPrefabInfo; }

    private void Awake()
    {
        synController = GetComponent<SynthesisController>();
        synManager = GetComponent<SynthesisManager>();
        synUIController = GetComponent<SynthesisUIController>();
        synPrefabInfo = GetComponent<SynthesisUIPrefabInfo>();
    }
}
