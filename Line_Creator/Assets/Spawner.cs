using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube, sphere, capsule;
    int whatToSpawn;
    int x = 0;
    public void Spawn(Vector3 position)
    {
        whatToSpawn = Random.Range (1,4);
        if(whatToSpawn == 1)
        {
            Instantiate(cube).transform.position = position;
        }
        else if(whatToSpawn == 2)
        {
            Instantiate(sphere).transform.position = position;
        }
        else if(whatToSpawn == 3)
        {
            Instantiate(capsule).transform.position = position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        // Vector3 spawnObjPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // transform.position = spawnObjPosition;
        // positionobj.position.x = spawnObjPosition.x;
        
        if(Input.GetMouseButton (1) && x==0)  
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Spawn(objPosition);
            x=1;
             StartCoroutine(Text());
            
        }     
    }
    

IEnumerator Text()  //  <-  its a standalone method
{
	// Debug.Log("Hello");
    yield return new WaitForSeconds(0.3f);
    // Debug.Log("ByeBye");
    x=0;
}
}
