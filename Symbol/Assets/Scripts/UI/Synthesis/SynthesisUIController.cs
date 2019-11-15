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


    /// <summary>
    /// Playerの所持クリスタルを合成画面内に表示
    /// </summary>
    /// <param name="bag"></param>
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
        // 所持種類分クリスタルを並べる
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
            crystal.transform.GetComponentInChildren<Text>().text = uiInfo.CrystalCount.ToString();
            crystal.GetComponent<Button>().onClick.AddListener(() => ClickCrystalList(crystal.GetComponent<Image>()));
            setCount++;
        }
    }

    /// <summary>
    /// つかんだクリスタルの情報をセット
    /// </summary>
    /// <param name="crystal"></param>
    void SetCatchData(Image crystal)
    {
        catchCrystalInfo.UIdata = crystal.sprite;
        catchCrystalInfo.dir = 0;
        catchCrystalInfo.crysData = crystal.GetComponent<CrystalUIInfo>().Info;
        synManager.CatchingCrystal = catchCrystalInfo;
    }

    /// <summary>
    /// 初めてつかんだ時に呼ばれる
    /// </summary>
    /// <param name="_touchCrystal"></param>
    private void GenerateCrystal(Image _touchCrystal)
    {
        synManager.CatchFlag = true;
        clickObject = Instantiate(Resources.Load("Prefabs/CatchCrystal") as GameObject, _touchCrystal.transform.root);
        clickObject.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// クリスタル選択
    /// </summary>
    /// <param name="_touch">クリックしたオブジェクト</param>
    public void ClickCrystalList(Image _touch) {
        // 何もつかんでいない時は、新たに生成
        if (!synManager.CatchFlag) {
            GenerateCrystal(_touch);
            synManager.ApplyCatchCrystal(catchCrystalInfo);
        }
        else　// つかんでた場合は切り替え
        {
            clickObject.GetComponent<CatchingCrystalMove>().ChangeCatchCrystal();
        }

        // それ以降は情報更新とUI切り替え
        clickObject.GetComponent<Image>().sprite = _touch.sprite;
        SetCatchData(_touch);
        synManager.ApplyCatchCrystal(catchCrystalInfo);
        clickObject.GetComponent<CatchingCrystalMove>().CatchData = synManager.CatchingCrystal;
        // つかんだクリスタルの数を1減らす
    }

    public void ChangeCatchCrystal(Image _catchObj)
    {
        _catchObj.GetComponent<CatchingCrystalMove>().CrystalRotation = 1;
        _catchObj.transform.rotation = Quaternion.identity;
        // つかんでいたクリスタルの数を1増やす
        // つかんだクリスタルの数を1減らす
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void ClickBox(GameObject me) {
        if (clickObject)
        {
            SynthesisBoxData boxData = me.GetComponent<SynthesisBoxData>();
            boxData.GetCatchingData(synManager.CatchingCrystal);
            clickObject.GetComponent<CatchingCrystalMove>().RemoveCatchData();
            clickObject = null;
            synManager.CatchFlag = false;
        }
    }

    // つかんでる素材の回転
    // 素材を離す(離した位置に素材を置く)
}
