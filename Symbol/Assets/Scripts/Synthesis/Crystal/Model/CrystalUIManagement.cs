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

    
    /// <summary>
    /// 選択クリスタル
    /// </summary>
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
    /// クリスタル選択時に必ず通る関数
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
    /// 持ち物クリスタル更新
    /// </summary>
    /// <param name="_icon"></param>
    /// <param name="_count"></param>
    public void ReflectUI(Sprite _icon, int _count)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = _icon;
        stack.text = _count.ToString();
    }
}
