using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = PSInputManager.Instance.LStickHorizontal * 100;
        float z = PSInputManager.Instance.LStickVertical * 100;
        rb.AddForce(new Vector3(x, 0, z));
        if (PSInputManager.Instance.CrossButton)
        {
            rb.AddForce(new Vector3(0,100,0));
        }
    }
}
