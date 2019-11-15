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
    private Transform crystalBoxUI;

    [SerializeField]
    private Image crystalUIMask;

    [SerializeField]
    private PlayerManager player;

    [SerializeField]
    private SynthesisManager synManager;

    private CatchingCrystal catchCrystalInfo;

    private GameObject clickObject;


    public void SetInfo(Dictionary<CrystalInfo.Data,int> bag) {
        int setCount = 0;
        if(bag == null)
        {
            // バッグに何もなかった時の処理
            Debug.Log("ナニモナイヨ");
            return;
        }

        Debug.Log("ナニカアッタヨ");
        // 1個以上
        // UIにクリスタル情報と数を追加、UIを情報内のiconに設定
        foreach (var i in bag)
        {
            GameObject crystal = Instantiate((GameObject)Resources.Load("Prefabs/CrystalPanel"), crystalUIMask.transform.GetChild(0));
            float UIWidth = crystal.GetComponent<RectTransform>().sizeDelta.x;
            float maskWidth = crystalUIMask.GetComponent<RectTransform>().sizeDelta.x;
            CrystalUIInfo uiInfo = crystal.GetComponent<CrystalUIInfo>();
            Vector2 firstPos = new Vector2(maskWidth * 0.5f * -1 + UIWidth * 0.5f,0);
            crystal.transform.localPosition = new Vector2(firstPos.x + UIWidth * setCount,0);
            uiInfo.Info = i.Key;
            uiInfo.CrystalCount = i.Value;
            crystal.GetComponent<Image>().sprite = i.Key.icon;
            crystal.GetComponent<Button>().onClick.AddListener(() => ClickCrystalList(crystal.GetComponent<Image>()));
            setCount++;
        }
    }

    void SetCatchData(Image crystal)
    {
        catchCrystalInfo.UIdata = crystal.sprite;
        catchCrystalInfo.dir = 0;
        catchCrystalInfo.crysData = crystal.GetComponent<CrystalUIInfo>().Info;
        synManager.CatchingCrystal = catchCrystalInfo;
    }

    /// <summary>
    /// クリスタル選択
    /// </summary>
    /// <param name="touch">クリックしたオブジェクト</param>
    public void ClickCrystalList(Image touch) {
        if (!synManager.CatchFlag) {
            synManager.CatchFlag = true;
            clickObject = Instantiate(Resources.Load("Prefabs/CatchCrystal") as GameObject, touch.transform.root);
            clickObject.GetComponent<Image>().sprite = touch.sprite;
            clickObject.transform.position = Input.mousePosition;
            synManager.ApplyCatchCrystal(catchCrystalInfo);
            SetCatchData(touch);
            return;
        }
        
        clickObject.GetComponent<Image>().sprite = touch.sprite;
        clickObject.GetComponent<CatchingCrystalMove>().CrystalRotation = 0;
        clickObject.transform.rotation = Quaternion.identity;
        SetCatchData(touch);
        synManager.ApplyCatchCrystal(catchCrystalInfo);

        
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void ClickBox(GameObject me) {
        SynthesisBoxData boxData = me.GetComponent<SynthesisBoxData>();
        boxData.GetCatchingData(synManager.CatchingCrystal);
    }

    // つかんでる素材の回転
    // 素材を離す(離した位置に素材を置く)
}
