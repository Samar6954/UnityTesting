using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // LineRenderer lr;
    public GameObject cube;

    public List<GameObject> myList = new List<GameObject>();
    public List<Vector3> values = new List<Vector3>();
    PolyLine poly1;

    int whatToSpawn;
    Vector3 objPosition;
    // LineRenderer lineRenderer;

    void Start()
  {
      
      poly1 = GameObject.Find("Polyline").GetComponent<PolyLine>();
   
  }

    public void Spawn_obj(Vector3 position)
    {
        whatToSpawn = Random.Range (1,2);
        if(whatToSpawn == 1)
        {
            GameObject temp =  Instantiate(cube, position, Quaternion.identity);
            Debug.Log(poly1);
            poly1.AddAnchor(temp);
            
            // myList.Add(cube);
            // values.Add(cube.transform.position);
            Debug.Log(cube.transform.position);
        }
     
    }
    // Update is called once per frame
    public void Update()
    {
        
        if(Input.GetMouseButtonDown (1))  
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z +
                transform.position.z);
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Spawn_obj(objPosition);

        }
    
    }
    
}
    
