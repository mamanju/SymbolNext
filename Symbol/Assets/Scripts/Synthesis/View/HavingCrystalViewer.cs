using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 所持しているクリスタルをUI上に並べる
/// </summary>
public class HavingCrystalViewer : MonoBehaviour
{
    [SerializeField]
    private CrystalUIController crystalUIController;
    [SerializeField]
    private RectTransform viewArea;
    [SerializeField]
    private CrystalDataList hogeList;

    private Dictionary<CrystalInfo.Data, int> hoge = new Dictionary<CrystalInfo.Data, int>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var i in hogeList.CrystalData)
            {
                hoge.Add(i.Value, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LineUpBag(hoge);
        }
    }

    /// <summary>
    /// 並べる処理
    /// </summary>
    /// <param name="bag"></param>
    public void LineUpBag(Dictionary<CrystalInfo.Data,int> bag)
    {
        GameObject crystal = crystalUIController.gameObject;
        Transform UIData = crystal.transform.GetChild(0).GetComponent<RectTransform>();
        float crystalWidth = UIData.GetComponent<RectTransform>().sizeDelta.x;
        float viewRadius = viewArea.sizeDelta.x * 0.5f;
        int count = 0;

        foreach(var i in bag)
        {
            crystal.GetComponent<Image>().sprite = i.Key.icon;
            crystal.GetComponent<CrystalUIController>().Info = i.Key;
            crystal.transform.GetChild(0).GetComponent<Text>().text = i.Value.ToString();
            Instantiate(crystal, viewArea.GetChild(0).transform);
            crystal.transform.localPosition = new Vector2(-viewRadius + crystalWidth * count , 0);
            count++;
        }
    }
}
