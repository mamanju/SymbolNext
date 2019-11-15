using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタル選択時にマウスに追従する処理
/// </summary>
public class CatchingCrystalMove : MonoBehaviour
{
    private int crystalRotation = 1;
    private CatchingCrystal catchData;
    private SynthesisManager synManager;

    /// <summary>
    /// つかんでいるクリスタルの情報
    /// </summary>
    public CatchingCrystal CatchData { get { return catchData; } set { catchData = value; } }

    /// <summary>
    /// 1から時計回りに、最大4
    /// </summary>
    public int CrystalRotation { get => crystalRotation; set => crystalRotation = value; }

    void Start()
    {
        synManager = GameObject.Find("SynthesisScript").GetComponent<SynthesisManager>();
    }

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
    /// クリスタルを離す度に呼ばれる、つかんだObjectの削除
    /// </summary>
    public void RemoveCatchData()
    {
        synManager.CatchingCrystal = new CatchingCrystal();
        Destroy(gameObject);
    }

    /// <summary>
    /// 別のクリスタルをつかんだ時の処理
    /// </summary>
    public void ChangeCatchCrystal()
    {
        crystalRotation = 1;
        transform.rotation = Quaternion.identity;
        // つかんでいたクリスタルの数を1増やす
    }

    /// <summary>
    /// クリスタルの回転
    /// </summary>
    private void RotateCrystal(int _dir)
    {
        catchData.dir += _dir;
        if(catchData.dir > 4)
        {
            catchData.dir = 1;
        }else if(catchData.dir < 1)
        {
            catchData.dir = 4;
        }
        transform.Rotate(0, 0, -90 * _dir);

        synManager.ApplyCatchCrystal(catchData);
    }
}
