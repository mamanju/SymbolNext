using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIの情報格納スクリプト
/// </summary>
public class CrystalUIInfo : MonoBehaviour
{
    private CrystalInfo.Data info;
    private int crystalCount = 0;

    public CrystalInfo.Data Info { get => info; set => info = value; }
    public int CrystalCount { get => crystalCount; set => crystalCount = value; }
}
