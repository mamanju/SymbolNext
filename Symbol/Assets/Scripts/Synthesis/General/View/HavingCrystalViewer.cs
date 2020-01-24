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
    private CatchingCrystal crystalUIController;
    [SerializeField]
    private RectTransform viewArea;
    [SerializeField]
    private CrystalDataList hogeList;

    private Dictionary<CrystalInfo.Data, int> hoge = new Dictionary<CrystalInfo.Data, int>();

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    foreach (var i in hogeList.CrystalData)
        //    {
        //        hoge.Add(i.Value, 1);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    LineUpBag(hoge);
        //}
    }

    /// <summary>
    /// 並べる処理
    /// </summary>
    /// <param name="_bag"></param>
    public void LineUpBag(Dictionary<CrystalInfo.Data,int> _bag)
    {
        GameObject crystal = crystalUIController.gameObject;

        Transform UIData = crystal.transform.GetComponent<RectTransform>();
        float crystalWidth = UIData.GetComponent<RectTransform>().sizeDelta.x;
        float viewRadius = viewArea.sizeDelta.x * 0.5f;
        int count = 0;

        foreach(var i in _bag)
        {
            Instantiate(crystal, viewArea.GetChild(0).transform);
            crystal.transform.localPosition = new Vector2(-viewRadius + crystalWidth * count , 0);
            //crystal.GetComponent<CrystalUIManagement>().ReflectUI(i.Key.icon, i.Value);
            count++;
        }
    }
}
