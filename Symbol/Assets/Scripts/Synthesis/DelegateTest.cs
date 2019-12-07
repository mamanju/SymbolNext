using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 渡す側
public class DelegateTest : MonoBehaviour
{
    void Start()
    {
        hoge();
    }

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

// 受け取る側
public class Hoge
{
    public delegate void Callback();

    public void Method(Callback action)
    {
        action();
    }
}
