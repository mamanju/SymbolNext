using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingCrystalController : MonoBehaviour
{
    private int crystalRotation = 1;
    private CatchingCrystalInfo catchData;
    private SynthesisUsecase usecase;

    /// <summary>
    /// 1から時計回りに、最大4
    /// </summary>
    public int CrystalRotation {
        get { return crystalRotation; }
        set {
            crystalRotation = value;
            if(crystalRotation < 1)
            {
                crystalRotation = 1;
            }else if(crystalRotation > 4)
            {
                crystalRotation = 4;
            }
        }
    }

    void Awake()
    {
        DuplicateCheck();
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
    /// クリスタル選択時に必ず通る関数
    /// </summary>
    /// <param name="_data"></param>
    public void SetSelectData(CrystalInfo.Data _data)
    {
        catchData.crysData = _data;
        catchData.UIdata = _data.icon;
        catchData.dir = 1;

        transform.rotation = Quaternion.identity;
        GetComponent<Image>().sprite = _data.icon;
    }

    void DuplicateCheck()
    {
        if (GameObject.FindGameObjectWithTag("CatchCrystal"))
        {
            Destroy(gameObject);
        }
    }

    public void ChangeInfo()
    {
        GetComponent<Image>().sprite = catchData.crysData.icon;
        crystalRotation = catchData.dir;
        transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// クリスタルを離す度に呼ばれる、つかんだObjectの削除
    /// </summary>
    public void RemoveCatchData()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// クリスタルの回転
    /// </summary>
    private void RotateCrystal(int _dir)
    {
        CrystalRotation += _dir;
        catchData.dir += crystalRotation;
        
        transform.Rotate(0, 0, -90 * crystalRotation);
    }
}
