using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 合成素材クリスタルのUI処理
/// </summary>
public class SynthesisPanelClick : MonoBehaviour
{
    private CrystalInfo cInfo;
    private CrystalUIInfo UIInfo;

    // 素材を選択する
    // 素材の情報を取得
    // 情報をもとに、選択した素材のUIを生成し、マウスに追従させる処理を入れる
    public void CatchCrystal()
    {
        GameObject catchIcon = Instantiate((GameObject)Resources.Load("Prefabs/CatchCrystal"));
        cInfo = GetComponent<CrystalInfo>();
        Instantiate(catchIcon);
        catchIcon.GetComponent<Image>().sprite = cInfo.data.icon;
    }

    // 素材の回転
    // 

    // マスを選択する
    // マスの子にあるImageのSpriteを選択した素材のUI(回転を含め)にする
}
