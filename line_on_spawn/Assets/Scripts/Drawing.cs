using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    Vector3 drawingPlaneVector = Vector3.forward;
    Plane drawingPlane;
    int whatToSpawn;
    GameObject newGO;
    // PolyLine poly1;
    // Start is called before the first frame update
    void Start()
    {
        drawingPlane = new Plane(drawingPlaneVector, Vector3.zero);
        newGO = new GameObject("Polyline");
        newGO.AddComponent<PolyLine>();
        // poly1 = GameObject.Find("Polyline").GetComponent<PolyLine>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance = 0.0f;

        bool hit = drawingPlane.Raycast(ray, out distance);
        Vector3 drawingPlaneCoordinate = ray.GetPoint(distance);
        
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetMouseButtonDown(1))
                {
                    whatToSpawn = Random.Range (1,4);
                    if(whatToSpawn == 1)
                    {
                        GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        newPoint.transform.position = drawingPlaneCoordinate;
                        newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                    }
                    else if(whatToSpawn == 2)
                    {
                        GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        newPoint.transform.position = drawingPlaneCoordinate;
                        newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                    }
                    else if(whatToSpawn == 3)
                    {
                        GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        newPoint.transform.position = drawingPlaneCoordinate;
                        newGO.GetComponent<PolyLine>().AddAnchorStart(newPoint);
                    }
                }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            whatToSpawn = Random.Range (1,4);
            if(whatToSpawn == 1)
            {
                GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newPoint.transform.position = drawingPlaneCoordinate;
                newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }
            else if(whatToSpawn == 2)
            {
                GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newPoint.transform.position = drawingPlaneCoordinate;
                newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }
            else if(whatToSpawn == 3)
            {
                GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                newPoint.transform.position = drawingPlaneCoordinate;
                newGO.GetComponent<PolyLine>().AddAnchor(newPoint);
            }
            
        }

        

        

    }
}
