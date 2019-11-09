using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 合成UIスクリプト
/// </summary>
public class SynthesisUIController : MonoBehaviour
{
    // 持ち物クリスタル
    [SerializeField]
    private GameObject crystalBoxUI;

    [SerializeField]
    private GameObject crystalUIMask;

    [SerializeField]
    private GameObject player;

    private GameObject clickObject;

    void Awake()
    {
        
    }

    public void SetInfo(Dictionary<CrystalInfo,int> bag) {
        int setCount = 0;
        if(bag.Count == 0)
        {
            // バッグに何もなかった時の処理
            return;
        }

        // 1個以上
        // UIにクリスタル情報と数を追加、UIを情報内のiconに設定
        foreach (var i in bag)
        {
            setCount++;
            GameObject crystal = Instantiate((GameObject)Resources.Load("Prefabs/CrystalPanel"), crystalUIMask.transform.GetChild(0));
            float posX = (crystalUIMask.GetComponent<RectTransform>().sizeDelta.x * 0.5f + crystal.GetComponent<RectTransform>().sizeDelta.x * 0.5f) * -1;
            Vector2 firstPos = new Vector2(crystalUIMask.GetComponent<RectTransform>().sizeDelta.x * 0.5f,0);
            crystal.transform.position = new Vector2(posX + crystal.GetComponent<RectTransform>().sizeDelta.x * setCount,0);
            crystal.GetComponent<CrystalUIInfo>().Info = i.Key;
            crystal.GetComponent<CrystalUIInfo>().CrystalCount = i.Value;
            crystal.GetComponent<Image>().sprite = i.Key.data.icon;
            crystal.GetComponent<Button>().onClick.AddListener(() => ClickCrystalList(crystal));
        }
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
