using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    private delegate void Oncomplete(string txt);
    void Start()
    {
        hoge();
    }

    private delegate void OnComplete();

    public void hoge()
    {
        Hoge huga = new Hoge();
        Hoge.Callback callback = DebugLog;
        huga.Method(callback);
    }

    public void DebugLog()
    {
        Debug.Log("やっほー");
    }
}

public class Hoge
{
    public delegate void Callback();

    public void Method(Callback action)
    {
        action();
    }
}
