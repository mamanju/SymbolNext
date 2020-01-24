using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クリスタルUI関連の表示処理クラス
/// </summary>
public class CrystalUIViewer : MonoBehaviour
{
    [SerializeField]
    private SynthesisUIPrefabInfo prefabList;

    #region 持ち物クリスタル

    [SerializeField]
    private RectTransform propertyViewArea;

    /// <summary>
    /// 生成
    /// </summary>
    /// <param name="_bag"></param>
    public void GenereteCrystalUI(Dictionary<CrystalInfo.Data, int> _bag) {
        List<GameObject> cryUIs = new List<GameObject>();
        List<int> cryCount = new List<int>();
        List<Sprite> cryIcon = new List<Sprite>();

        foreach(var i in _bag) {
            GameObject cryUI = prefabList.CrystalUIPrefab.gameObject;
            Instantiate(cryUI,propertyViewArea);
            cryUIs.Add(cryUI);
            cryCount.Add(i.Value);
            cryIcon.Add(i.Key.icon);
        }
        InfluenceCrystalInBag(cryUIs, cryCount, cryIcon);
    }

    /// <summary>
    /// 並べる
    /// </summary>
    private void InfluenceCrystalInBag(List<GameObject> _crystals,List<int> _possetion,List<Sprite> _icons)
    {
        float uiWidth = _crystals[0].GetComponent<RectTransform>().sizeDelta.x;
        float viewRadius = propertyViewArea.sizeDelta.x * 0.5f;
        int count = 0;

        foreach(var i in _crystals)
        {
            i.transform.localPosition = new Vector3(-viewRadius + uiWidth * count, 0,0);
            i.GetComponent<Image>().sprite = _icons[count];
            count++;
            Debug.Log(count);
        }
    }


    #endregion

    #region 選択クリスタル

    /// <summary>
    /// 情報をもとに反映
    /// </summary>
    /// <param name="_crystal"></param>
    /// <param name="_icon"></param>
    public void InfluenceCatchingCrystal(Image _crystal,Sprite _icon)
    {
        _crystal.sprite = _icon;
        _crystal.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// 回転
    /// </summary>
    /// <param name="_crystal"></param>
    /// <param name="_dir"></param>
    public void CatchCrystalRotation(Image _crystal, int _dir)
    {
        _crystal.transform.Rotate(0, 0, 90 * _dir);
    }

    #endregion


}
