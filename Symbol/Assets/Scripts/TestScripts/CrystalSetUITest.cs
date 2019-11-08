using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CrystalSetUITest : MonoBehaviour
{
    private Vector3 worldMousePos;

    // クリスタルをつかんでるかどうかの状態(0:Default、1:Catch)
    private bool catchFlag = false;

    // 今つかんでるクリスタル
    private GameObject catchingCrystal;

    // 持ち物クリスタル
    private GameObject crystalBox;

    [SerializeField]
    private SynthesisManager sManager;

    [SerializeField]
    private Image[] SynthesisPieces;

    /// <summary>
    /// 初期化
    /// </summary>
    void SynthesisUIInit()
    {
        worldMousePos = new Vector3(0, 0, 0);
        catchFlag = false;
    }

    /// <summary>
    /// 持ち物クリスタルの表示
    /// </summary>
    void IndicateCrystalUI()
    {
        foreach(var i in sManager.GetCrystalBox)
        {
            foreach(var j in Common.Instance.GetPrefabData)
            {
                if(i.Key.data.form != j.crystalForm)
                {
                    continue;
                }
                // クリスタルUIを表示
                // GetCrystalBoxのValue分の値を追加
            }
        }
    }

    void CatchCrystal()
    {
        
    }

    void DivideCrystal()
    {

    }

    void ClickCheck(GameObject obj)
    {
        if (!catchFlag)
        {
            CatchCrystal();
        }
        else
        {
            DivideCrystal();
        }
    }
}
