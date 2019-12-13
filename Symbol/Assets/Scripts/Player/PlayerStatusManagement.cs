using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManagement : MonoBehaviour
{
    private Dictionary<CrystalInfo.Data, int> myBag = new Dictionary<CrystalInfo.Data, int>();

    /// <summary>
    /// 持ち物
    /// </summary>
    public Dictionary<CrystalInfo.Data,int> MyBag { get { return myBag; } set { myBag = value; } }
    

}
