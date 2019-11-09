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

    private PlayerStatus player;

    public Dictionary<CrystalInfo, int> GetCrystalBox { get { return playersCrystal; } }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>().GetStatus;
    }

    /// <summary>
    /// 必要なデータの取り出し
    /// </summary>
    void SetData()
    {
        playersCrystal = null;
        Dictionary<CrystalInfo, int> pCrystalBox;
        playersCrystal = player.CrystalBag;
        GetComponent<SynthesisUIController>().SetInfo(playersCrystal);
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
    /// プレイヤーの持ち物を更新
    /// </summary>
    /// <param name="bag"></param>
    public void ApplyHaveCrystal(List<CrystalInfo> bag)
    {
        //bag = playersCrystal;
    }
}
