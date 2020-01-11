using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クリスタル選択時にUI生成
/// </summary>
public class GenereteSelectCrystalUI : MonoBehaviour
{
    [SerializeField]
    private Image selectUI;
    [SerializeField]
    private Canvas synthesisCanvas;

    void RotateCrystal(int _dir)
    {

    }

    public void Generete(CrystalInfo.Data _data)
    {
        selectUI.sprite = _data.icon;
        Instantiate(selectUI.gameObject, synthesisCanvas.transform);
        selectUI.transform.position = Input.mousePosition;
    }

    public void ReflectDirection()
    {

    }
}
