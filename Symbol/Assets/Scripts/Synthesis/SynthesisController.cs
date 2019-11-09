using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成コントローラー
/// </summary>
public class SynthesisController : SynthesisManager
{
    /// <summary>
    /// 合成素材の箱[クリスタル,回転][タテ,ヨコ]
    /// </summary>
    private Dictionary<CrystalInfo, int>[,] synthesisBox = new Dictionary<CrystalInfo, int>[2, 2];
    private SynthesisUIController UIController;

    private void Init()
    {
        synthesisBox = null;
        UIController = GetComponent<SynthesisUIController>();
    }

    void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 選んだクリスタルを入れる
    /// </summary>
    /// <param name="crystal">クリスタル情報[クリスタル,回転]</param>
    /// <param name="boxPos">箱の位置[タテ,ヨコ]</param>
    public void ChooseCrystal(Dictionary<CrystalInfo,int> crystal,int[] boxPos)
    {
        synthesisBox[boxPos[0], boxPos[1]] = crystal;
        // 所持してるクリスタルから選んだクリスタルの数を減らす
    }

    /// <summary>
    /// 箱からクリスタルの削除
    /// </summary>
    public void DeleteCrystal()
    {
        // 所持してるクリスタルから選んだクリスタルの数を戻す
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
