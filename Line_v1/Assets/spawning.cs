using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject cube, sphere, capsule;
    // private Transform[] points_1;
    // public Transform[] points_1;
    public static List<GameObject> myList = new List<GameObject>();
    
    int whatToSpawn;
    public void Spawn(Vector3 position)
    {
        whatToSpawn = Random.Range (1,4);
        if(whatToSpawn == 1)
        {
            Instantiate(cube).transform.position = position;
            myList.Add(cube);
        }
        else if(whatToSpawn == 2)
        {
            Instantiate(sphere).transform.position = position;
            myList.Add(sphere);
        }
        else if(whatToSpawn == 3)
        {
            Instantiate(capsule).transform.position = position;
            myList.Add(capsule);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown (1))  
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Spawn(objPosition);
            // if(myList.Count != 0)
                Debug.Log(myList.Count);
                // test = GameObject.Find("Main Camera").GetComponent<lr_Test>();
                // points_1 = myList.ToArray().transform;
        }
        // Camera.main.GetComponent
    }
}
    
