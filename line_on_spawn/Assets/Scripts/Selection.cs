using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public GameObject selectedGO = null;
    Vector3 drawingPlaneVector = -Vector3.forward;
    Plane drawingPlane;
    // PolyLine deleteGO;
    GameObject GO;
    
    // Start is called before the first frame update
    void Start()
    {
        drawingPlane = new Plane(drawingPlaneVector, Vector3.zero); 
        
    }

    // Update is called once per frame
    void Update()
    {
        // deleteGO = GameObject.Find("Polyline").GetComponent<PolyLine>();
        GO = GameObject.Find("Polyline");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitinfo;
        float distance;

        bool hit = drawingPlane.Raycast(ray, out distance);

        Vector3 drawingPlaneCoordinate = ray.GetPoint(distance);

        

        if (Input.GetKey(KeyCode.LeftControl))
         {
             if(Input.GetMouseButtonDown(0))
                {
                    // Debug.Log("Ctrl+mouse_left");
                    if (Physics.Raycast(ray, out hitinfo))
                        {
                            selectedGO = hitinfo.transform.gameObject;
                            Debug.Log("Delete");
                    //     }
                    // if (selectedGO != null)
                    //     {
                            for(int i=0; i<GO.GetComponent<PolyLine>().anchors.Count; i++)
                            {
                                if(GO.GetComponent<PolyLine>().anchors[i].transform.position == selectedGO.transform.position)
                                   GO.GetComponent<PolyLine>().DeleteAnchorAt(i);
                                    // GO.GetComponent<PolyLine>().Update();
                            }
                            // Destroy(selectedGO);
                        }
                }
         }

        else if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitinfo))
            {
                selectedGO = hitinfo.transform.gameObject;
                Debug.Log(selectedGO.name);
            }
        }

        else if(Input.GetMouseButtonUp(0))
        {
            selectedGO = null;
        }

        if (Input.GetMouseButton(0))
        {
            if (selectedGO != null)
            {
                selectedGO.transform.position = drawingPlaneCoordinate;
            }
        }
    }
}
