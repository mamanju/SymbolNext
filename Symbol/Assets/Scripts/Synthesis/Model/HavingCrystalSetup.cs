using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成画面表示時、現在のクリスタルを取得
/// </summary>
public class HavingCrystalSetup : MonoBehaviour
{
    /// <summary>
    /// 合成画面表示フラグ
    /// </summary>
    public bool SynthesisFlag = false;

    private Dictionary<CrystalInfo.Data, int> crystalBag = new Dictionary<CrystalInfo.Data, int>();

    [SerializeField]
    private PlayerStatusManagement playerManagement;

    /// <summary>
    /// 持ち物取得
    /// </summary>
    private void GetMyBagData()
    {
        crystalBag = playerManagement.MyBag;
        // UIに並べる処理を呼び出し
    }
}
