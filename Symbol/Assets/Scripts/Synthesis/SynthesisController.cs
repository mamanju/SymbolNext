using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成コントローラー
/// </summary>
public class SynthesisController : SynthesisMaster
{
    /// <summary>
    /// 合成素材の箱[クリスタル,回転][タテ,ヨコ]
    /// </summary>
    private Dictionary<CrystalInfo, int>[,] synthesisBox = new Dictionary<CrystalInfo, int>[2, 2];

    //レシピと参照するための変数
    private int[] referenceRecipe;

    public void Init()
    {
        synthesisBox = null;
    }

    /// <summary>
    /// 箱からクリスタルの削除
    /// </summary>
    public void DeleteCrystal()
    {
        // 所持してるクリスタルから選んだクリスタルの数を戻す
    }

    /// <summary>
    /// クリスタルをつかむ
    /// </summary>
    public void CatchCrystal(CatchingCrystalInfo _data)
    {
        synthesisManager.ApplyCatchCrystal(_data);

        // つかんだクリスタルの数を1減らす
    }

    /// <summary>
    /// クリスタルを離す
    /// </summary>
    public void RemoveCrystal()
    {

    }

    /// <summary>
    /// 合成
    /// </summary>
    public void Synthesis()
    {
        // 合成のフェイズを「合成」に進める

        // 素材合成箱の情報と、レシピを比較

        // True：ManagerクラスのPlayersCrystalに、合成箱と同じレシピのクリスタルを入れる

        // False：ManagerクラスのPlayersCrystalに、失敗クリスタルを入れる

        // 合成に使ったクリスタルを消費

        // 合成図のフェイズを「素材箱選択」に戻す
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
