using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー情報(設定)
/// </summary>
[System.Serializable]
public struct PlayerStatus
{
    private int MaxHP { get; set; }
    private int hp;
    public int HP { get { return hp; } set { hp = value; } }

    private int attack;
    public int Attack { get { return attack; } set { attack = value; } }

    private Dictionary<CrystalInfo, int> crystalBag;

    public Dictionary<CrystalInfo, int> CrystalBag { get { return crystalBag; } set { crystalBag = value; } }

}

/// <summary>
/// プレイヤー管理クラス
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus status;

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
