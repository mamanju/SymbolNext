using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CrystalのPrefabを呼び出すために参照するスクリプト
/// </summary>
public class CrystalPrefabList : MonoBehaviour
{
    [System.Serializable]
    public struct PrefabData
    {
        public string crystalName;
        public Sprite icon;
        public GameObject model;
    }

    [SerializeField]
    private PrefabData[] data;
}
