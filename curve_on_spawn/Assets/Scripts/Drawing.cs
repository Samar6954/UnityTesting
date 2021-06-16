using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    Vector3 drawingPlaneVector = Vector3.forward;
    Plane drawingPlane;
    int whatToSpawn;
    GameObject newGO;
    
    void Start()
    {
        drawingPlane = new Plane(drawingPlaneVector, Vector3.zero);
        newGO = new GameObject("Polyline");
        newGO.AddComponent<PolyLine>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance = 0.0f;

        bool hit = drawingPlane.Raycast(ray, out distance);
        Vector3 drawingPlaneCoordinate = ray.GetPoint(distance);
        
       
        if(Input.GetMouseButtonDown(1))
        {
            whatToSpawn = Random.Range (1,4);
            if(whatToSpawn == 1)
            {
                GameObject newPoint = 
                    GameObject.CreatePrimitive(PrimitiveType.Cube);
                newPoint.transform.position = drawingPlaneCoordinate;
                if (Input.GetKey(KeyCode.LeftShift))
                    newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                else
                    newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }
            else if(whatToSpawn == 2)
            {
                GameObject newPoint = 
                    GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newPoint.transform.position = drawingPlaneCoordinate;
                if (Input.GetKey(KeyCode.LeftShift))
                    newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                else
                    newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }
            else if(whatToSpawn == 3)
            {
                GameObject newPoint = 
                    GameObject.CreatePrimitive(PrimitiveType.Capsule);
                newPoint.transform.position = drawingPlaneCoordinate;
                if (Input.GetKey(KeyCode.LeftShift))
                    newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                else
                    newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }            
        }
    }
}
