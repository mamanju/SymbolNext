using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成関連のクラスが継承するクラス
/// </summary>
public class SynthesisMaster : MonoBehaviour
{
    private SynthesisUsecase usecase;

    protected SynthesisManager synthesisManager;
    protected SynthesisController synthesisController;
    protected SynthesisUIController synthesisUIController;

    void Awake()
    {
        synthesisManager = GetComponent<SynthesisManager>();
        synthesisController = GetComponent<SynthesisController>();
        synthesisUIController = GetComponent<SynthesisUIController>();

        // 各クラス初期化
        synthesisController.Init();
        synthesisManager.Init();
        synthesisUIController.Init();
    }
}
