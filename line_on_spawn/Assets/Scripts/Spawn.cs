using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // LineRenderer lr;
    public GameObject cube;
    // public Transform[] points_1;
    public List<GameObject> myList = new List<GameObject>();
    public List<Vector3> values = new List<Vector3>();
    PolyLine poly1;
    // public static List<Vector3> temp = new List<Vector3>();
    // public Vector3[] myList_v ;
    // Vector3[] myList_v;
    int whatToSpawn;
    Vector3 objPosition;
    // LineRenderer lineRenderer;

    void Start()
  {
      
      poly1 = GameObject.Find("Polyline").GetComponent<PolyLine>();
    // Adding LineRenderer Component to the gameObject,
    // to which this script is attached to
    //  LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    // lineRenderer.SetWidth(0.4f, 0.4f);
    // Getting the LineRenderer Component which is 
    // attached to this gameObject
    // lr = GetComponent<LineRenderer>();
  }

    public void Spawn_obj(Vector3 position)
    {
        whatToSpawn = Random.Range (1,2);
        if(whatToSpawn == 1)
        {
            GameObject temp =  Instantiate(cube, position, Quaternion.identity) ;
            Debug.Log(poly1);
            poly1.AddAnchor(temp);
            
            // myList.Add(cube);
            // values.Add(cube.transform.position);
            Debug.Log(cube.transform.position);
        }
        // else if(whatToSpawn == 2)
        // {
        //     Instantiate(sphere).transform.position = position;
        //     myList.Add(sphere);
        //     // values.Add(sphere.transform.position);
        //     Debug.Log(sphere.transform.position);
        // }
        // else if(whatToSpawn == 3)
        // {
        //     Instantiate(capsule).transform.position = position;
        //     myList.Add(capsule);
        //     // values.Add(capsule.transform.position);
        //     Debug.Log(capsule.transform.position);
        // }
    }
    // Update is called once per frame
    public void Update()
    {
        
        if(Input.GetMouseButtonDown (1))  
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Spawn_obj(objPosition);
           
                // Debug.Log(myList.Count);
                
        // lineRenderer = GetComponent<LineRenderer>();
        // int lengthOfLineRenderer = myList.Count;
        // lineRenderer.positionCount = lengthOfLineRenderer ;
        
        
        // myList_v = new Vector3[myList.Count];
       
        //     temp.Add(objPosition);
        //     myList_v[myList.Count-1] = objPosition;
        //     if(myList_v.Length>1)
        //     {
        //         for(int i=0; i<temp.Count-1; i++)
        //         {
        //             myList_v[i] = temp[i];
        //         }
        //     }
        //     // for(int i=0; i<myList.Count; i++)
        //     //     {
        //     //         values[i] = myList[i].transform.position;
        //     //     }
        //     // Debug.Log(myList_v[0]);
        
        // lineRenderer.SetPositions(myList_v);
        }
    
    }
    
}
    
