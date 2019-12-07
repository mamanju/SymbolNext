using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIの情報格納スクリプト
/// </summary>
public class CrystalUIController : MonoBehaviour
{
    private CrystalInfo.Data info;
    private int crystalCount = 0;
    private SynthesisUsecase usecase;
    private Text stack;

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
        GetComponent<Button>().onClick.AddListener(() => ClickAction(info));
        stack = transform.GetComponentInChildren<Text>();
        ReflectUI();
    }

    void ClickAction(CrystalInfo.Data data)
    {
        
    }

    private void GenerateCatchCrystal()
    {
        GameObject catchUI = usecase.SynPrefabInfo.CrystalUIPrefab.gameObject;
        usecase.SynManager.CatchFlag = true;
        catchUI = Instantiate(catchUI, transform.root);
        catchUI.transform.position = Input.mousePosition;
    }


    void ReflectUI()
    {
        GetComponent<Image>().sprite = info.icon;
        stack.text = crystalCount.ToString();
    }
}
