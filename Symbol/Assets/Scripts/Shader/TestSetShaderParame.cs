using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetShaderParame : MonoBehaviour
{
    private bool m_OutLine = false;
    private Material m_material = null;
    // Start is called before the first frame update
    void Start()
    {
        m_OutLine = false;
        m_material = GetComponent<Renderer>().material;
        m_material.SetFloat("_IsOutLineON", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutLine()
    {
        if(m_OutLine)
        {
            m_material.SetFloat("_IsOutLineON", 0);
            m_OutLine = false;
            return;
        }else
        {
            m_material.SetFloat("_IsOutLineON", 1);
            m_OutLine = true;
        }
    }
}
