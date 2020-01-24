using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingCrystalViewer : MonoBehaviour
{
    [SerializeField]
    private SynthesisUsecase usecase;
    /// <summary>
    /// クリスタル生成
    /// </summary>
    /// <param name="_info"></param>
    public void GeneretePickCrystal(CrystalInfo.Data _info)
    {
        var crystal = usecase.SynPrefabInfo.CatchCrystalUIPrefab;
        crystal.GetComponent<CrystalUIManagement>().SetSelectData(_info);
    }



    /// <summary>
    /// クリスタル更新
    /// </summary>
    /// <param name="_info"></param>
    public void ChangePickCrystal(CatchingCrystalInfo _info)
    {

    }

    public void ReflectSprite(Sprite _icon)
    {
        GetComponent<Image>().sprite = _icon;
    }

    /// <summary>
    /// 回転リセット
    /// </summary>
    public void ResetRotate()
    {
        transform.rotation = Quaternion.identity;
    }
}
