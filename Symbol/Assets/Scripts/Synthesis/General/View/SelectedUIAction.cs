using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選んでいるクリスタルUIが持つ情報
/// </summary>
public class SelectedUIAction : MonoBehaviour
{
    [SerializeField]
    private SynthesisInfomationManagement synthesisInfomationManagement;
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }

    public void RotationCrystal(int _dir)
    {
        synthesisInfomationManagement.selectingCrystal.CrystalDirection += _dir;
        transform.Rotate(0, 0, 90 * _dir);
    }
}
