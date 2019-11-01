using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルの情報
/// </summary>
public class CrystalInfo
{
    /// <summary>
    /// 記号の形
    /// </summary>
    public string form;

    public enum Type
    {
        wood,
        Iron,
        Rock,
        other,
    }

    /// <summary>
    /// 材質
    /// </summary>
    public Type type;
}