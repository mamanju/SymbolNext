using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSetUITest : MonoBehaviour
{
    private Vector3 worldMousePos;
    private int mouseState = 0;
    private GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameObject hitObj = null;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit = new RaycastHit();
        //    if(Physics.Raycast(ray, out hit))
        //    {
        //        hitObj = hit.collider.gameObject;
        //    }
        //    Debug.Log("Object=" + hitObj);
        //}
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickedGameObject);
        }



    }

    void CatchCrystal()
    {
        
    }

    void DivideCrystal()
    {

    }

    void ClickCheck(GameObject obj)
    {
        if (mouseState == 0)
        {
            CatchCrystal();
        }
        else
        {
            DivideCrystal();
        }
    }
}
