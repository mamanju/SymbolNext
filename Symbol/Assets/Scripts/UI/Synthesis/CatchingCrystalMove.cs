using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタル選択時にマウスに追従する処理
/// </summary>
public class CatchingCrystalMove : MonoBehaviour
{
    //0から時計回りに、最大3
    private int crystalRotation;

    public int GetCrystalRotaion { get { return crystalRotation; } }
    void Update()
    {
        transform.localPosition = Input.mousePosition;
        // クリスタルの回転
    }

    /// <summary>
    /// クリスタルの回転
    /// </summary>
    private void RotateCrystal()
    {
        crystalRotation++;
        if(crystalRotation > 3)
        {
            crystalRotation = 0;
        }else if(crystalRotation < 0)
        {
            crystalRotation = 3;
        }
    }
}
