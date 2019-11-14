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

    public Dictionary<CrystalInfo.Data, int> CrystalBag;

}

/// <summary>
/// プレイヤー管理クラス
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public PlayerStatus status;

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

    [SerializeField]
    private CrystalDataList dataList;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dictionary<CrystalInfo.Data, int> tempData = new Dictionary<CrystalInfo.Data, int>();
            foreach(var i in dataList.CrystalData) {
                tempData.Add(i.Value, 1);
            }
            PlayerStatus pStatus = new PlayerStatus();
            pStatus.CrystalBag = tempData;
            ApplyStatus(pStatus);
            Debug.Log("データイレタヨ");
        }
    }
}
