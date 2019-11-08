using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー情報(設定)
/// </summary>
[System.Serializable]
public struct PlayerStatus
{
    public int MaxHP;
    public int Hp;
    public int Attack;

    public Dictionary<CrystalInfo, int> CrystalBag;

}

/// <summary>
/// プレイヤー管理クラス
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public PlayerStatus status;

    /// <summary>
    /// テスト用スクリプト
    /// </summary>
    void TestCrystalSet()
    {

    }

    /// <summary>
    /// プレイヤー情報(管理)
    /// </summary>
    public PlayerStatus GetStatus{ get { return status; }}

    /// <summary>
    /// プレイヤー情報更新
    /// </summary>
    /// <param name="data"></param>
    public void ApplyStatus(PlayerStatus data)
    {
        status = data;
    }
}
