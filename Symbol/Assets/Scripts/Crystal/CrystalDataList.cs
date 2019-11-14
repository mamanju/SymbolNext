using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルデータ設定
/// </summary>
public class CrystalDataList : MonoBehaviour
{
    public CrystalInfo.Data[] dataList;
    private Dictionary<string, CrystalInfo.Data> crystalData = new Dictionary<string, CrystalInfo.Data>();

    /// <summary>
    /// クリスタルデータ参照変数
    /// </summary>
    public Dictionary<string, CrystalInfo.Data> CrystalData { get => crystalData; set => crystalData = value; }

    void Awake()
    {
        foreach(var i in dataList)
        {
            CrystalData.Add(i.form, i);
        }
    }
}
