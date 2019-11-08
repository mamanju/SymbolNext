using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 合成UIスクリプト
/// </summary>
public class SynthesisUI : MonoBehaviour
{
    // 持ち物クリスタル
    [SerializeField]
    private GameObject crystalBoxUI;

    [SerializeField]
    private GameObject crystalUIMask;

    [SerializeField]
    private GameObject player;

    private GameObject clickObject;

    void SetInfo() {
        int setCount = 0;
        PlayerStatus status = player.GetComponent<PlayerManager>().GetStatus;
        if(status.CrystalBag.Count == 0)
        {
            // バッグに何もなかった時の処理
            return;
        }

        // 1個以上
        foreach (var i in status.CrystalBag)
        {
            setCount++;
            GameObject crystal = Resources.Load("Prefabs/CrystalPanel") as GameObject;
            Instantiate(crystal, crystalUIMask.transform.GetChild(0));
            Vector2 firstPos = new Vector2(crystalUIMask.GetComponent<RectTransform>().sizeDelta.x * 0.5f,0);
            crystal.transform.position = new Vector2(firstPos.x + (crystal.GetComponent<RectTransform>().sizeDelta.x * 0.5f) * setCount,0);
            crystal.GetComponent<CrystalUIInfo>().Info = i.Key;
            crystal.GetComponent<Button>().onClick.AddListener(() => ClickCrystalList(crystal));
        }
    }

    void NaraberuTest()
    {
        int createCount = 10;
        for(int i = 1; i <= createCount; i++)
        {
            GameObject crystal = Resources.Load("Prefabs/CrystalPanel") as GameObject;
            Vector2 firstPos = new Vector2(crystalUIMask.GetComponent<RectTransform>().sizeDelta.x * 0.5f, 0);
            crystal.transform.position = new Vector2(firstPos.x + (crystal.GetComponent<RectTransform>().sizeDelta.x * 0.5f) * i, 0);

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
