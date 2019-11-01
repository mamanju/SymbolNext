using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成の管理
/// </summary>
public class SynthesisManager : MonoBehaviour
{
    //プレイヤーが所持しているクリスタル
    private Dictionary<CrystalInfo, int> playersCrystal;
    private List<int> crystalStock;

    // クリスタルをつかんでるかどうかの状態(0:Default、1:Catch)
    private bool catchFlag = false;

    // 今つかんでるクリスタル
    private GameObject catchingCrystal;
    // 持ち物クリスタル
    private List<CrystalInfo> crystalBox;

    public Dictionary<CrystalInfo, int> GetCrystalBox { get { return playersCrystal; } }

    /// <summary>
    /// 必要なデータの取り出し
    /// </summary>
    void SetData()
    {
        PlayerStatus player = GameObject.Find("Player").GetComponent<PlayerManager>().GetStatus;
        Dictionary<CrystalInfo, int> pCrystalBox;
        pCrystalBox = player.CrystalBag;
        foreach (var i in pCrystalBox)
        {
            playersCrystal.Add(i.Key, i.Value);
        }
    }

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
        //playersCrystal = bag;
    }

    /// <summary>
    /// プレイヤーの持ち物を更新
    /// </summary>
    /// <param name="bag"></param>
    public void ApplyHaveCrystal(List<CrystalInfo> bag)
    {
        //bag = playersCrystal;
    }
}
