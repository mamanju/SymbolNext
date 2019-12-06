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

    public CrystalInfo.Data Info { get => info; set => info = value; }
    public int CrystalCount { get => crystalCount; set => crystalCount = value; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ClickCallback());
        ReflectUI();
    }

    void ClickCallback()
    {

    }

    void ReflectUI()
    {
        GetComponent<Image>().sprite = info.icon;
        transform.GetComponentInChildren<Text>().text = crystalCount.ToString();
    }
}
