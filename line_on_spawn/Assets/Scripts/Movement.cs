using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Rigidbody rb;
    // Start is called before the first frame update
    // Vector3 Smallest;
    // float comparison;
    // int index;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Debug.Log(objPosition);
        transform.position = objPosition;
        // rb.isKinematic = true;
    }

    // void Update()
    // {
    //     if(Input.GetMouseButtonDown (0))
    //     {
    //         Vector3 mousePosition1 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
    //         Vector3 objPosition1 = Camera.main.ScreenToWorldPoint(mousePosition1);
    //         // Debug.Log(objPosition1);
    //         for(int i=0; i<Spawn.temp.Count; i++)
    //         {
    //             comparison = Mathf.Abs(Spawn.temp[0][1]-objPosition1[1]);
    //             Smallest = Spawn.temp[0];
    //             if(Mathf.Abs(Spawn.temp[i][1]-objPosition1[1])<comparison)
    //                { 
    //                    Smallest = Spawn.temp[i];
    //                    index = i;
    //                }
                
    //         }
    //         // Debug.Log(index);
    //     }

    //     if(Input.GetMouseButtonUp (0))
    //     {
    //         Vector3 mousePosition2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
    //         Vector3 objPosition2 = Camera.main.ScreenToWorldPoint(mousePosition2);
    //         Spawn.temp[index] = objPosition2;
    //         // Debug.Log(Spawn.temp[index]);
    //     }  
    // }

}
