using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 合成UIスクリプト
/// </summary>
public class SynthesisUIController : SynthesisMaster
{
    [SerializeField]
    private SynthesisUsecase usecase;
    // 持ち物クリスタル
    [SerializeField]
    private Transform crystalBoxUI;

    [SerializeField]
    private Image crystalUIMask;

    [SerializeField]
    private PlayerManager player;

    private GameObject clickObject;

    public void Init()
    {
        clickObject = null;
    }

    /// <summary>
    /// Playerの所持クリスタルを合成画面内に表示
    /// </summary>
    /// <param name="_bag"></param>
    public void SetInfo(Dictionary<CrystalInfo.Data,int> _bag) {
        int setCount = 0;
        if(_bag == null)
        {
            // バッグに何もなかった時の処理
            Debug.Log("ナニモナイヨ");
            return;
        }

        Debug.Log("ナニカアッタヨ");
        // 1個以上
        // 所持種類分クリスタルを並べる
        // UIにクリスタル情報と数を追加、UIを情報内のiconに設定
        foreach (var i in _bag)
        {
            GameObject crystal = Instantiate(usecase.SynPrefabInfo.CrystalUIPrefab.gameObject, crystalBoxUI);
            float UIWidth = crystal.GetComponent<RectTransform>().sizeDelta.x;
            float maskWidth = crystalUIMask.GetComponent<RectTransform>().sizeDelta.x;
            CrystalUIController uiInfo = crystal.GetComponent<CrystalUIController>();
            Vector2 firstPos = new Vector2(maskWidth * 0.5f * -1 + UIWidth * 0.5f,0);

            crystal.transform.localPosition = new Vector2(firstPos.x + UIWidth * setCount,0);
            uiInfo.Info = i.Key;
            uiInfo.CrystalCount = i.Value;
            crystal.GetComponent<Button>().onClick.AddListener(() => ClickCrystalList(crystal.GetComponent<Image>()));
            setCount++;
        }
    }

    private void GenereteMyCrystal(Dictionary<CrystalInfo.Data, int> _bag)
    {
        GameObject crystal = Instantiate((GameObject)Resources.Load("Prefabs/CrystalPanel"), crystalUIMask.transform.GetChild(0));
        float UIWidth = crystal.GetComponent<RectTransform>().sizeDelta.x;
        float maskWidth = crystalUIMask.GetComponent<RectTransform>().sizeDelta.x;
        CrystalUIController uiInfo = crystal.GetComponent<CrystalUIController>();
        Vector2 firstPos = new Vector2(maskWidth * 0.5f * -1 + UIWidth * 0.5f, 0);

    }

    /// <summary>
    /// クリスタル選択
    /// </summary>
    /// <param name="_touch">クリックしたオブジェクト</param>
    public void ClickCrystalList(Image _touch)
    {
        // 何もつかんでいない時は、新たに生成
        if (!synthesisManager.CatchFlag)
        {
            GenerateCatchCrystal(_touch);
        }
        else　// つかんでた場合は切り替え
        {
            ChangeCatchCrystal(_touch);
        }

        clickObject.GetComponent<Image>().sprite = _touch.sprite;
        SetCatchCrystalData(_touch);
        clickObject.GetComponent<CatchingCrystalController>().CatchData = synthesisManager.CatchingCrystal;

    }

    /// <summary>
    /// つかんだクリスタルの情報をセット
    /// </summary>
    /// <param name="crystal"></param>
    void SetCatchCrystalData(Image crystal)
    {
        CatchingCrystalInfo info = new CatchingCrystalInfo();
        info.UIdata = crystal.GetComponent<CrystalUIController>().Info.icon;
        info.crysData = crystal.GetComponent<CrystalUIController>().Info;
        info.dir = 1;
        synthesisController.CatchCrystal(info);
        crystal.sprite = synthesisManager.CatchingCrystal.UIdata;
        crystal.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// 初めてつかんだ時に呼ばれる
    /// </summary>
    /// <param name="_touchCrystal"></param>
    private void GenerateCatchCrystal(Image _touchCrystal)
    {
        GameObject catchUI = new GameObject();
        synthesisManager.CatchFlag = true;
        catchUI = Instantiate(Resources.Load("Prefabs/CatchCrystal") as GameObject, _touchCrystal.transform.root);
        catchUI.transform.position = Input.mousePosition;
        clickObject = catchUI;

    }

    /// <summary>
    /// クリスタルを持ち替えた時の処理
    /// </summary>
    /// <param name="_catchObj"></param>
    public void ChangeCatchCrystal(Image _catchObj)
    {
        clickObject.GetComponent<CatchingCrystalController>().CrystalRotation = 1;
        clickObject.transform.rotation = Quaternion.identity;
        // つかんでいたクリスタルの数を1増やす
        // つかんだクリスタルの数を1減らす
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void ClickBox(GameObject _me) {
        if (!synthesisManager.CatchFlag) { return; }
        
        SynthesisBoxData boxData = _me.GetComponent<SynthesisBoxData>();
        boxData.ClickSynthesisBox(synthesisManager.CatchingCrystal);
        clickObject.GetComponent<CatchingCrystalController>().RemoveCatchData();
        clickObject = null;
        synthesisManager.CatchFlag = false;
    }

    // つかんでる素材の回転
    // 素材を離す(離した位置に素材を置く)
}
