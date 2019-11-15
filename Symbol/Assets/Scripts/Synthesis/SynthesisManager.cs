using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// つかんでるクリスタル情報(オブジェクト、クリスタルの情報、回転)
/// </summary>
public struct CatchingCrystal
{
    public Sprite UIdata;
    public CrystalInfo.Data crysData;
    public int dir;
}

/// <summary>
/// 合成の管理
/// </summary>
public class SynthesisManager : MonoBehaviour
{
    //プレイヤーが所持しているクリスタル
    private Dictionary<CrystalInfo.Data, int> playersCrystal;
    private List<int> crystalStock;

    // クリスタルをつかんでるかどうかの状態(0:Default、1:Catch)
    private bool catchFlag = false;

    private CatchingCrystal catchingCrystal;

    // 今つかんでるクリスタル
    //private GameObject catchingCrystal;
    // 持ち物クリスタル
    private List<CrystalInfo> crystalBox;

    [SerializeField]
    protected PlayerManager player;

    public Dictionary<CrystalInfo.Data, int> GetCrystalBox { get { return playersCrystal; } }

    public CatchingCrystal CatchingCrystal { get => catchingCrystal; set => catchingCrystal = value; }
    public bool CatchFlag { get => catchFlag; set => catchFlag = value; }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            SetData();
        }
    }

    /// <summary>
    /// 必要なデータの取り出し
    /// </summary>
    void SetData()
    {
        playersCrystal = null;
        PlayerStatus pStatus = player.GetStatus;
        playersCrystal = pStatus.CrystalBag;
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
            playersCrystal.Remove(i.data);
        }    
    }

    /// <summary>
    /// プレイヤーの持ち物を更新
    /// </summary>
    /// <param name="bag"></param>
    public void ApplyCatchCrystal(CatchingCrystal catchData)
    {
        catchingCrystal = catchData;
    }

    /// <summary>
    /// 合成マスに情報を入れる
    /// </summary>
    /// <param name="data"></param>
    /// <param name="dir"></param>
    public void SettingBox(CrystalInfo.Data data,int dir)
    {

    }
}
