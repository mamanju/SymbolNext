using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成コントローラー
/// </summary>
public class SynthesisController : SynthesisManager
{
    // 合成素材の箱
    private CrystalInfo[] chooseBox = new CrystalInfo[5];

    // 合成結果の箱
    private int synshesisID = 0x0000;

    int synthesisBox = 0x0000;
    int aCrystal = 0x5000;
    int bCrystal = 0x0a00;
    int cCrystal = 0x00b0;
    int dCrystal = 0x000c;

    int swordCrystal = 0x5abc;
    // Start is called before the first frame update
    void Start()
    {
        synthesisBox = aCrystal | bCrystal | cCrystal | dCrystal;
        if(synthesisBox == swordCrystal)
        {
            Debug.Log("True");
        }
        Debug.Log("テスト＝"+System.Convert.ToString(synthesisBox,16));
    }

    /// <summary>
    /// 選んだクリスタルを入れる
    /// </summary>
    /// <param name="crystal"></param>
    /// <param name="num"></param>
    public void ChooseCrystal(CrystalInfo crystal,int num)
    {
        chooseBox[num] = crystal;
        // 所持してるクリスタルから選んだクリスタルの数を減らす
    }

    /// <summary>
    /// 箱からクリスタルの削除
    /// </summary>
    /// <param name="num"></param>
    public void DeleteCrystal(int num)
    {
        chooseBox[num] = null;
        // 所持してるクリスタルから選んだクリスタルの数を戻す
    }

    /// <summary>
    /// 合成
    /// </summary>
    public void Synthesis()
    {
        // 合成のフェイズを「合成」に進める
        Phase = SynthesisPhase.Synthesis;

        // 素材合成箱の値と、クリスタル情報のIDを比較

        // True：ManagerクラスのPlayersCrystalに、合成箱と同じIDのクリスタルを入れる

        // False：ManagerクラスのPlayersCrystalに、失敗クリスタルを入れる

        // 合成に使ったクリスタルを消費
        RemoveCrystal(chooseBox);

        // 合成図のフェイズを「素材箱選択」に戻す
        Phase = SynthesisPhase.BoxChoose;
    }

    /// <summary>
    /// 合成前にソート
    /// </summary>
    /// <param name="box"></param>
    /// <returns></returns>
    //public CrystalInfo[] CrystalSort(CrystalInfo[] box) {
    //    CrystalInfo[] crystalBox = box;
    //    bool sortFlag = false;
    //    // バブルソート
    //    do {
    //        int temp = 0;
    //        sortFlag = false;
    //        for (int i = 0; i > crystalBox.Length - 1; i++) {
    //            if (crystalBox[i].info.ID < crystalBox[i + 1].info.ID) {
    //                temp = crystalBox[i].info.ID;
    //                crystalBox[i].info.ID = crystalBox[i + 1].info.ID;
    //                crystalBox[i + 1].info.ID = temp;
    //                sortFlag = true;
    //            }
    //        }
    //    } while (!sortFlag);
    //    return box;
    //}
}
