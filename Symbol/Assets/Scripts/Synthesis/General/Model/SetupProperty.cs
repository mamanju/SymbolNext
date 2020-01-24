using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成画面表示時、現在のクリスタルを取得
/// </summary>
public class SetupProperty :MonoBehaviour
{
    private Dictionary<CrystalInfo.Data, int> crystalBag = new Dictionary<CrystalInfo.Data, int>();

    [SerializeField]
    private PlayerStatusManagement playerManagement;

    [SerializeField]
    private SynthesisInfomationManagement synthesisManagement;

    private CrystalUIViewer crystalUIViewer;

    private void Start() {
        crystalUIViewer = GetComponent<CrystalUIViewer>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            GetMyBagData();
        }
    }

    /// <summary>
    /// 持ち物取得
    /// </summary>
    private void GetMyBagData() {
        synthesisManagement.tempCrystalBag = playerManagement.MyBag;
        crystalUIViewer.GenereteCrystalUI(synthesisManagement.tempCrystalBag);
        // UIに並べる処理を呼び出し
    }
}
    
