﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 合成UIスクリプト
/// </summary>
public class SynthesisUI : MonoBehaviour
{
    // 持ち物クリスタル
    private CrystalInfo[] crystalBox;
    private GameObject clickObject;

    void SetInfo() {
        // 所持アイテムのUIを反映
        // 
    }

    void Update() {
        
    }

    void ClickCrystalList(GameObject obj) {
        Debug.Log(obj);
    }

    /// <summary>
    /// 持ち物クリスタルから、使う素材をつかむ
    /// </summary>
    void CatchCrystal()
    {

    }
    // つかんでる素材の回転
    // 素材を離す(離した位置に素材を置く)
}