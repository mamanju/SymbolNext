using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] CameraTriggerParameter sf_cameraParameter = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag != "Player") { return; }
        CameraManager.Instance.StartCameraMove(sf_cameraParameter.SetOffSet, sf_cameraParameter.SetMaxDistance, other.transform.gameObject);
    }

}
