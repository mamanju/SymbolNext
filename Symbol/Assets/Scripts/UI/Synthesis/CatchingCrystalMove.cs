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
    private CatchingCrystal catchData;
    private SynthesisManager synManager;

    public CatchingCrystal CatchData { get { return catchData; } set { catchData = value; } }

    public int CrystalRotation { get => crystalRotation; set => crystalRotation = value; }

    void Start()
    {
        synManager = GameObject.Find("SynthesisScript").GetComponent<SynthesisManager>();
        catchData = synManager.CatchingCrystal;
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
    /// クリスタルの回転
    /// </summary>
    private void RotateCrystal(int dir)
    {
        catchData.dir += dir;
        
        if(catchData.dir > 3)
        {
            catchData.dir = 0;
        }else if(catchData.dir < 0)
        {
            catchData.dir = 3;
        }
        Debug.Log(catchData.dir);
        transform.Rotate(0, 0, -90 * dir);
        synManager.ApplyCatchCrystal(catchData);
    }
}
