using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルの情報
/// </summary>
public class CrystalInfo : MonoBehaviour
{
    [System.Serializable]
    public struct Crystal
    {
        [Header("合成時に参照する")]
        public int ID;
        public enum Type
        {
            Original,
            Weapon,
            Item,
        }
        [Header("クリスタル使用時に参照する")]
        public Type type;
    }

    public Crystal info;
}
