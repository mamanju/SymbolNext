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
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ClickAction());
        stack = transform.GetComponentInChildren<Text>();
    }

    void ClickAction()
    {
        
    }

    private void GenerateCatchCrystal()
    {
        GameObject catchUI = usecase.SynPrefabInfo.CrystalUIPrefab.gameObject;
        usecase.SynManager.CatchFlag = true;
        catchUI = Instantiate(catchUI, transform.root);
        catchUI.transform.position = Input.mousePosition;
    }


    public void ReflectUI(Sprite _icon, int _count)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = _icon;
        stack.text = _count.ToString();
    }
}
