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
    private CrystalInfo.Data catchData;

    public CrystalInfo.Data CatchData { get => catchData; set => catchData = value; }
    public int CrystalRotation { get => crystalRotation; set => crystalRotation = value; }

    void Update()
    {
        transform.position = Input.mousePosition;
        // クリスタルの回転
        if (Input.GetKeyDown(KeyCode.A)) {
            RotateCrystal(-1);
        }else if (Input.GetKeyDown(KeyCode.D)) {
            RotateCrystal(1);
        }
    }

    /// <summary>
    /// クリスタルの回転
    /// </summary>
    private void RotateCrystal(int dir)
    {
        CrystalRotation += dir;
        if(CrystalRotation > 3)
        {
            CrystalRotation = 0;
        }else if(CrystalRotation < 0)
        {
            CrystalRotation = 3;
        }
        Debug.Log(CrystalRotation);
        transform.Rotate(0, 0, -90 * dir);
    }
}
