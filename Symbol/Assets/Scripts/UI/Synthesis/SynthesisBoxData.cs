using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesisBoxData : MonoBehaviour
{
    private CatchingCrystal setCrystalData;

    public CatchingCrystal SetCrystalData { get => setCrystalData; set => setCrystalData = value; }

    public void RefleshBoxData(Image icon)
    {
        icon.sprite = null;
        icon.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void GetCatchingData(CatchingCrystal data)
    {
        Image icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        RefleshBoxData(icon);
        SetCrystalData = data;
        icon.sprite = setCrystalData.UIdata;
        icon.transform.Rotate(0, 0, 90 * -data.dir);
        
    }
}
