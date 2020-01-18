﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcingCrystal : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateCrystal(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateCrystal(-1);
        }
    }

    /// <summary>
    /// クリスタル回転
    /// </summary>
    /// <param name="_dir"></param>
    private void RotateCrystal(int _dir)
    {
        transform.Rotate(0, 0, 90 * _dir);
    }
}
