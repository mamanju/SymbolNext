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

    [SerializeField]
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

    public void GenerateCatchCrystal()
    {
        GameObject catchUI = usecase.SynPrefabInfo.CatchCrystalUIPrefab.gameObject;
        if (!DuplicateCheck(catchUI))
        {
            catchUI = Instantiate(catchUI, transform.root);
            catchUI.GetComponent<CatchingCrystalController>().SetSelectData(info);
            catchUI.transform.position = Input.mousePosition;
        }
        else
        {

        }

    }

    private bool DuplicateCheck(GameObject _clone)
    {
        if (GameObject.Find(_clone.name))
        {
            return false;
        }
        return true;
    }


    public void ReflectUI(Sprite _icon, int _count)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = _icon;
        stack.text = _count.ToString();
    }
}
