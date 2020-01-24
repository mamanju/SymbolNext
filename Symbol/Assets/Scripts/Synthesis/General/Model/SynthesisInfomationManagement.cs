using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SelectingCrystalInfo {
    public CrystalInfo.Data SelectingCrystal;
    private int crystalDirection;
    /// <summary>
    /// クリスタルの回転管理
    /// </summary>
    public int CrystalDirection
    {
        get { return crystalDirection; }
        set
        {
            crystalDirection = value;
            if (crystalDirection < 1)
            {
                crystalDirection = 4;
            }
            else if (crystalDirection > 4)
            {
                crystalDirection = 1;
            }
        }
    }
}
/// <summary>
/// 合成情報管理クラス
/// </summary>
public class SynthesisInfomationManagement : MonoBehaviour
{
    /// <summary>
    /// 合成画面表示フラグ
    /// </summary>
    [HideInInspector]
    public bool SynthesisFlag = false;

    public SelectingCrystalInfo selectingCrystal;

    [HideInInspector]
    public Dictionary<CrystalInfo.Data, int> tempCrystalBag = new Dictionary<CrystalInfo.Data, int>();

}
