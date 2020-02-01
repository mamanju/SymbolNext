using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingCrystal : MonoBehaviour
{
    private CatchingCrystalInfo info;

    public CatchingCrystalInfo Info { get => info; set => info = value; }

    private void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCrystal(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
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
