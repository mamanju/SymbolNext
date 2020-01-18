using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct CatchingCrystalInfo
{
    public Sprite UIdata;
    public CrystalInfo.Data crysData;
    public int dir;
}

/// <summary>
/// UIの情報格納スクリプト
/// </summary>
public class CrystalUIManagement : MonoBehaviour
{
    private CrystalInfo.Data info;
    private int crystalCount = 0;
    private SynthesisUsecase usecase;
    private Text stack;

    /// <summary>
    /// 持ち物クリスタル
    /// </summary>
    private List<Button> propertyCrystals = new List<Button>();
    
    /// <summary>
    /// 選択クリスタル
    /// </summary>
    private CatchingCrystalInfo catchCrystal;

    public CrystalInfo.Data Info { get { return info; } set { info = value; } }
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

    void Start()
    {
        usecase = FindObjectOfType<SynthesisUsecase>();
        stack = transform.GetComponentInChildren<Text>();
    }

    /// <summary>
    /// クリスタル選択時にどの関数を呼ぶか
    /// </summary>
    public void CatchActionSelect()
    {
        // 生成
        if (!DuplicateCheck())
        {
            GenerateCatchCrystal();
        }
        else // 変更
        {
            //ReflectUI();
        }
        
    }

    /// <summary>
    /// 選択したクリスタル生成
    /// </summary>
    public void GenerateCatchCrystal()
    {
        var catchUI = usecase.SynPrefabInfo.CatchCrystalUIPrefab;
        catchUI = Instantiate(catchUI, transform.root);
        catchUI.transform.position = Input.mousePosition;
        SetSelectData(info);
    }

    /// <summary>
    /// クリスタル選択時に必ず通る関数
    /// </summary>
    /// <param name="_data"></param>
    public void SetSelectData(CrystalInfo.Data _data)
    {
        catchCrystal.crysData = _data;
        catchCrystal.UIdata = _data.icon;
        catchCrystal.dir = 1;

        transform.rotation = Quaternion.identity;
        GetComponent<Image>().sprite = _data.icon;
    }

    private bool DuplicateCheck()
    {
        if (GameObject.FindGameObjectWithTag("CatchCrystal"))
        {
            return false;
        }
        return true;
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
