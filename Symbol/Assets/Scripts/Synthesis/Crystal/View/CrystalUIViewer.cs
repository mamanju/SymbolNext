using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クリスタルUI関連の処理クラス
/// </summary>
public class CrystalUIViewer : MonoBehaviour
{

    #region 持ち物クリスタル

    [SerializeField]
    private RectTransform propertyViewArea;

    /// <summary>
    /// 並べる
    /// </summary>
    public void InfluenceCrystalInBag(List<Image> _crystals,List<int> _possetion,List<Sprite> _icons)
    {
        float uiWidth = _crystals[0].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        float viewRadius = propertyViewArea.sizeDelta.x * 0.5f;
        int count = 1;

        foreach(var i in _crystals)
        {
            i.transform.SetParent(propertyViewArea);
            i.transform.position = new Vector2(-viewRadius * uiWidth * count, 0);
            count++;
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
