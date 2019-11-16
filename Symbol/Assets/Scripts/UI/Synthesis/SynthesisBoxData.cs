using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesisBoxData : MonoBehaviour
{
    private CatchingCrystalInfo settingCrystalData;

    public CatchingCrystalInfo SetingCrystalData { get => settingCrystalData; set => settingCrystalData = value; }

    private bool crystalSetFlag = false;

    private SynthesisManager synManager;

    public void RefleshBoxData(Image _icon)
    {
        _icon.sprite = null;
        _icon.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void ClickSynthesisBox(CatchingCrystalInfo _data)
    {
        if (!crystalSetFlag)
        {
            SetCrystalData(_data);
        }
        else
        {
            GetCrystalData();
        }
    }

    /// <summary>
    /// つかんでいるクリスタルをセットする
    /// </summary>
    /// <param name="_data"></param>
    void SetCrystalData(CatchingCrystalInfo _data)
    {
        Image icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        RefleshBoxData(icon);
        settingCrystalData = _data;
        icon.sprite = settingCrystalData.UIdata;
        icon.transform.Rotate(0, 0, 90 * (-_data.dir + 1));
    }

    /// <summary>
    /// セットされているクリスタルを取り出す
    /// </summary>
    void GetCrystalData()
    {
        synManager = GameObject.Find("SynthesisScript").GetComponent<SynthesisManager>();
    }


}
