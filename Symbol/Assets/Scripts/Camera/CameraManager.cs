using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager m_instance = null;

    private Camera m_camera = null;

    private Vector3 m_startMoveCameraPosition = Vector3.zero;

    private Vector3 m_finishMoveCameraPosition = Vector3.zero;

    private Vector3 m_startMovePlayerPosition = Vector3.zero;

    private Vector3 m_finishMovePlayerPosition = Vector3.zero;

    private Vector3 m_OffSet = Vector3.zero;

    private float m_maxChangeDistance = 0;

    private GameObject m_playerObj = null;

    private bool m_isRootMove = false;

    public static CameraManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        m_playerObj = GameObject.FindGameObjectWithTag("Player");
        m_camera = Camera.main;
        m_maxChangeDistance = 0;
        m_isRootMove = false;
        m_OffSet = new Vector3(0, 5, -5);
        this.transform.position = m_playerObj.transform.position + m_OffSet;

        this.transform.LookAt(m_playerObj.transform.position);
    }
    private void FixedUpdate()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        if (m_isRootMove)
        {
            float nowPlayerPositionDistance = Vector3.Distance(m_startMovePlayerPosition, m_playerObj.transform.position);
            float maxDistanceRatio = Mathf.Clamp(nowPlayerPositionDistance / m_maxChangeDistance, 0, 1);
            //this.transform.position = Vector3.Slerp(m_startMoveCameraPosition, m_finishMoveCameraPosition, maxDistanceRatio);
            m_OffSet = Vector3.Slerp(m_startMoveCameraPosition, m_finishMoveCameraPosition, maxDistanceRatio);
        }
        Debug.Log(m_playerObj);
        m_camera.transform.position = m_playerObj.transform.position + m_OffSet;
        m_camera.transform.LookAt(m_playerObj.transform.position);
    }

    public void StartCameraMove(Vector3 finishCaeraPosition, float maxChangeDistance, GameObject playerObj)
    {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }

        m_startMoveCameraPosition = m_camera.transform.position;

        m_finishMoveCameraPosition = m_OffSet;

        m_startMovePlayerPosition = playerObj.transform.position;

        m_maxChangeDistance = maxChangeDistance;

       // m_playerObj = playerObj;
        m_isRootMove = true;
    }

    public void endCameraMove()
    {

        //m_playerObj = null;
        //m_isRootMove = false;
    }
}
