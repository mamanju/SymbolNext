using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成の管理
/// </summary>
public class SynthesisManager : MonoBehaviour
{
    //プレイヤーが所持しているクリスタル
    protected List<CrystalInfo> playersCrystal;
    // フェイズのEnum
    public enum SynthesisPhase
    {
        CrystalChoose,
        BoxChoose,
        Synthesis,
        finish,
    }
    private SynthesisPhase phase;
    /// <summary>
    /// 合成のフェイズ
    /// </summary>
    public SynthesisPhase Phase{ get { return phase; } set { phase = value; } }

    /// <summary>
    /// 合成後に、使ったクリスタルを消費
    /// </summary>
    /// <param name="box"></param>
    protected void RemoveCrystal(CrystalInfo[] box)
    {
        foreach(var i in box)
        {
            if (i == null) { continue; }
            playersCrystal.Remove(i);
        }    
    }

    /// <summary>
    /// 所持しているクリスタルを取得
    /// </summary>
    public void GetHaveCrystals(List<CrystalInfo> bag)
    {
        playersCrystal = bag;
    }

    /// <summary>
    /// プレイヤーの持ち物を更新
    /// </summary>
    /// <param name="bag"></param>
    public void ApplyHaveCrystal(List<CrystalInfo> bag)
    {
        bag = playersCrystal;
    }
}
