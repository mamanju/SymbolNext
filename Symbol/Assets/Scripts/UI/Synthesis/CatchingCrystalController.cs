using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クリスタル選択時にマウスに追従する処理
/// </summary>
public class CatchingCrystalController : MonoBehaviour
{
    private int crystalRotation = 1;
    private CatchingCrystalInfo catchData;
    private SynthesisUsecase usecase;

    /// <summary>
    /// つかんでいるクリスタルの情報
    /// </summary>
    public CatchingCrystalInfo CatchData { get { return catchData; } set { catchData = value; } }

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

    void Start()
    {
        usecase = GameObject.Find("SynthesisScript").GetComponent<SynthesisUsecase>();
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
        usecase.SynManager.CatchingCrystal = new CatchingCrystalInfo();
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
        usecase.SynManager.ApplyCatchCrystal(catchData);
    }
}
