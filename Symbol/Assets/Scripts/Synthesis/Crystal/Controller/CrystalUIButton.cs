using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalUIButton : MonoBehaviour
{
    private CrystalChooseAction synthesisUIScript;
    private CrystalInfo.Data myData;

    public CrystalInfo.Data MyData { get { return myData; } set { myData = value; } }

    private void Start()
    {
        synthesisUIScript = GameObject.FindGameObjectWithTag("UIControll").GetComponent<CrystalChooseAction>();
    }

    public void ChooseSend()
    {
        synthesisUIScript.ClickActionSend(MyData);
    }
}
