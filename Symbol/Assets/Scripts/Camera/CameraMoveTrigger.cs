using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] CameraTriggerParameter sf_cameraParameter = null;

    private bool m_PlayerIn = false;
    private void Start()
    {
        m_PlayerIn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag != "Player") { return; }

        if(!m_PlayerIn)
        {
            sf_cameraParameter.MemoryOffSet = CameraManager.Instance.OffSet;
            CameraManager.Instance.StartCameraMove(sf_cameraParameter.SetOffSet, sf_cameraParameter.SetMaxDistance);
            m_PlayerIn = true;
            return;
        }
        else
        {
            CameraManager.Instance.StartCameraMove(sf_cameraParameter.MemoryOffSet, sf_cameraParameter.SetMaxDistance);
            sf_cameraParameter.MemoryOffSet = Vector3.zero;
            m_PlayerIn = false;
        }
    }

}
