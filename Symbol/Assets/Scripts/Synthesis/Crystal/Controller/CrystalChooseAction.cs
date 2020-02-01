using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// クリスタルのUI（Button）を押した際の処理分け
/// </summary>
public class CrystalChooseAction : MonoBehaviour
{
    private CrystalUIManagement crystalUIManagement;

    private void Start()
    {
        crystalUIManagement = GetComponent<CrystalUIManagement>();
    }

    /// <summary>
    /// クリスタル選択時のcallback
    /// </summary>
    /// <param name="_data"></param>
    public void ClickActionSend(CrystalInfo.Data _data)
    {
        if(crystalUIManagement.CatchingCrystal == null)
        {
            GenereteCrystal(_data);
        }
        else
        {
            ChangeToBag(_data);
        }
    }

    private CrystalInfo.Data crystalInfo;
    // bag内のクリスタルをクリック（生成）
    public void GenereteCrystal(CrystalInfo.Data _data)
    {
        crystalUIManagement.GenerateCatchCrystal(_data);
    }
    // bag内のクリスタルをクリック（変更）
    public void ChangeToBag(CrystalInfo.Data _data)
    {

    }
    // 合成Box内をクリック（配置）
    public void DispositionToBox(int _num)
    {

    }
    // 合成Box内をクリック（取り出し）
    public void PickUpToBox(int _num)
    {

    }

    // 合成Box内をクリック（変更）
    public void ChangeToBox(int _num)
    {

    }
}
