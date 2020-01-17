using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// つかんでるクリスタル情報(Sprite、クリスタルの情報、回転)
/// </summary>
//public struct CatchingCrystalInfo
//{
//    public Sprite UIdata;
//    public CrystalInfo.Data crysData;
//    public int dir;
//}

/// <summary>
/// 合成の管理
/// </summary>
public class SynthesisManager : SynthesisMaster
{
    public enum SynthesisPhase
    {
        Choose,
        Synthesis,
        Result,
    }
    
    [HideInInspector]
    public SynthesisPhase Phase;

    //プレイヤーが所持しているクリスタル
    private Dictionary<CrystalInfo.Data, int> playersCrystal;

    // クリスタルをつかんでるかどうかの状態(0:Default、1:Catch)
    private bool catchFlag = false;

    private CatchingCrystalInfo catchingCrystal;

    // 持ち物クリスタル
    private List<CrystalInfo> crystalBag;

    // 合成の箱
    private float[] synthesisBox = new float[9];

    [SerializeField]
    private PlayerManager player;

    /// <summary>
    /// 必ず2の倍数
    /// </summary>
    [SerializeField]
    private int maxCrystalRotation;

    public Dictionary<CrystalInfo.Data, int> CrystalBag { get { return playersCrystal; } set { playersCrystal = value; } }

    public CatchingCrystalInfo CatchingCrystal { get => catchingCrystal; set => catchingCrystal = value; }
    public bool CatchFlag { get => catchFlag; set => catchFlag = value; }
    public float[] SynthesisBox { get => synthesisBox; set => synthesisBox = value; }

    public void Init()
    {
        crystalBag = null;
        catchingCrystal = new CatchingCrystalInfo();
        catchFlag = false;
        playersCrystal = null;
    }

    void Update() {
        // デバッグ用
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
        //PlayerStatus pStatus = player.GetStatus;
        //playersCrystal = pStatus.CrystalBag;
        synthesisUIController.SetInfo(playersCrystal);
    }

    /// <summary>
    /// 合成後に、使ったクリスタルを消費
    /// </summary>
    /// <param name="_box"></param>
    protected void RemoveCrystal(CrystalInfo[] _box)
    {
        foreach(var i in _box)
        {
            if (i == null) { continue; }
            playersCrystal.Remove(i.data);
        }    
    }

    /// <summary>
    /// プレイヤーの持ち物を更新
    /// </summary>
    /// <param name="bag"></param>
    public void ApplyCatchCrystal(CatchingCrystalInfo _catchData)
    {
        catchingCrystal = _catchData;
        // つかんだクリスタルの数を1減らす
    }

    /// <summary>
    /// 合成マスに情報を入れる
    /// </summary>
    /// <param name="_data"></param>
    /// <param name="_dir"></param>
    public void SettingBox(CrystalInfo.Data _data,int _dir)
    {

    }
}
