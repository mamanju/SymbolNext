using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct CatchingCrystalInfo
{
    public CrystalInfo.Data crysData;
    public Sprite UIdata;
    public int dir;
}

/// <summary>
/// UIの情報格納スクリプト
/// </summary>
public class CrystalUIManagement : MonoBehaviour
{
    private int crystalCount = 0;
    private SynthesisUsecase usecase;
    private Text stack;

    [SerializeField]
    private Canvas synthesisCanvas;

    [SerializeField]
    private CrystalUIViewer crystalUIViewer;

    /// <summary>
    /// 持ち物クリスタル
    /// </summary>
    private List<Button> propertyCrystals = new List<Button>();

    // 合成マス
    [SerializeField]
    private GameObject synthesisBoxes;

    private GameObject catchingCrystal;

    public int CrystalCount {
        get { return crystalCount; }
        set {
            crystalCount = value;
            if(stack == null)
            {
                stack = transform.GetComponentInChildren<Text>();
            }
            stack.text = crystalCount.ToString();
        }
    }
    
    /// <summary>
    /// 選択クリスタル 
    /// </summary>
    public GameObject CatchingCrystal { get { return catchingCrystal; }  set { catchingCrystal = value; } }

    void Start()
    {
        usecase = FindObjectOfType<SynthesisUsecase>();
        stack = transform.GetComponentInChildren<Text>();
    }
    
    /// <summary>
    /// 選択したクリスタル生成
    /// </summary>
    public void GenerateCatchCrystal(CrystalInfo.Data _data)
    {
        var catchUI = usecase.SynPrefabInfo.CatchCrystalUIPrefab;
        catchUI = Instantiate(catchUI, synthesisCanvas.transform);
        catchUI.transform.position = Input.mousePosition;
        catchingCrystal = catchUI.gameObject;
        SetSelectData(catchUI.GetComponent<Image>(),_data);
    }

    /// <summary>
    /// 選択したクリスタルの情報格納（クリスタル選択時に必ず通す）
    /// </summary>
    /// <param name="_data"></param>
    public void SetSelectData(Image _catchUI,CrystalInfo.Data _data)
    {
        CatchingCrystalInfo info = catchingCrystal.GetComponent<CatchingCrystal>().Info;
        info.crysData = _data;
        info.UIdata = _data.icon;
        info.dir = 1;
        crystalUIViewer.InfluenceCatchingCrystal(_catchUI, _data.icon);
    }

    /// <summary>
    /// 合成Boxに配置
    /// </summary>
    public void Disposition(int _num)
    {
        SynthesisBoxData boxData = synthesisBoxes.transform.GetChild(_num).GetComponent<SynthesisBoxData>();
        CatchingCrystalInfo catchInfo = catchingCrystal.GetComponent<CatchingCrystal>().Info;

        boxData.SetingCrystalData = catchInfo;
        crystalUIViewer.ReflectBoxUI(boxData.gameObject);
    }
}
