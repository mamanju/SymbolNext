using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventManager : MonoBehaviour
{
    //private static MouseEventManager m_Instance = null;

    //public static MouseEventManager Instance
    //{
    //    get
    //    {
    //        if (m_Instance == null)
    //        {
    //            GameObject obj = new GameObject("EventManager");
    //            m_Instance = obj.AddComponent<MouseEventManager>();
    //        }

    //        return m_Instance;
    //    }
    //}

    private PlayerManager m_PlayerManager = null;

    void Start()
    {
        m_PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void MouseClickUpdate()
    {
        if (!Input.GetMouseButtonDown(0)) { return; }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycast;

        if (!Physics.Raycast(ray, out raycast)) { return; }
     //   m_PlayerManager.NextPosition(raycast.point);
    }
}
