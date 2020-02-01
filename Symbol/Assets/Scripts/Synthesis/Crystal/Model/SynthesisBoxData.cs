using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マス内の格納情報管理
/// </summary>
public class SynthesisBoxData : MonoBehaviour
{
    private GameObject UIScriptsObject;
    private CrystalChooseAction chooseAction;
    private CrystalUIManagement UIManagement;

    private CatchingCrystalInfo settingCrystalData;

    // クリスタル情報（回転など）
    public CatchingCrystalInfo SetingCrystalData { get => settingCrystalData; set => settingCrystalData = value; }

    private bool crystalSetFlag = false;

    [SerializeField]
    private int boxNum;

    void Start()
    {
        UIScriptsObject = GameObject.FindGameObjectWithTag("UIControll");
        chooseAction = UIScriptsObject.GetComponent<CrystalChooseAction>();
        UIManagement = UIScriptsObject.GetComponent<CrystalUIManagement>();
    }

    public void RefleshBoxData(Image _icon)
    {
        _icon.sprite = null;
        _icon.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// 合成マスクリック時
    /// </summary>
    public void ClickSynthesisBox()
    {

        if (!UIManagement.CatchingCrystal)
            if (!crystalSetFlag)
            {
                return;
            }
            else
            {
                chooseAction.PickUpToBox(boxNum);
                return;
            }

        if (!crystalSetFlag)
        {
            chooseAction.DispositionToBox(boxNum);
        }
        else
        {
            chooseAction.ChangeToBox(boxNum);
        }
    }

    /// <summary>
    /// つかんでいるクリスタルをセットする
    /// </summary>
    /// <param name="_data"></param>
    void SetCrystalData(CatchingCrystalInfo _data)
    {  
        Image icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        RefleshBoxData(icon);
        settingCrystalData = _data;
        if (settingCrystalData.crysData.symmetry)
        {
            SymmetryMode();
        }
        icon.sprite = settingCrystalData.UIdata;
        icon.transform.Rotate(0, 0, 90 * (-_data.dir + 1));
    }

    /// <summary>
    /// セットしたクリスタルが対称の場合の処理
    /// </summary>
    void SymmetryMode()
    {
        if(settingCrystalData.dir == 3)
        {
            settingCrystalData.dir = 1;
        }else if(settingCrystalData.dir == 4)
        {
            settingCrystalData.dir = 2;
        }
    }

    /// <summary>
    /// レシピ参照のために数値変換
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="dir"></param>
    float ParseSetNum(int _ID,int _dir)
    {
        float parseNum = 1f;
        parseNum += _ID * 0.1f;
        parseNum += boxNum * 0.01f;
        parseNum += _dir * 0.001f;
        if(parseNum > 1)
        {
            parseNum *= 0.1f;
        }
        parseNum += 1;
        return parseNum;
    }
}
