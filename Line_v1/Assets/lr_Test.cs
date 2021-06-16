using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_Test : MonoBehaviour
{
public List<GameObject> myList_1 = new List<GameObject>();
    // [SerializeField] private Transform[] points;
    // private Transform[] points = spawning.myList.ToArray();
    [SerializeField] private lr_LineControl line;
    // Start is called before the first frame update
    void Start()
    {
        myList_1 = spawning.myList;
        Transform[] myList_v = new Transform[myList_1.Count];
        for(int i = 0; i<myList_1.Count; i++)
        {
            
            myList_v[i] = myList_1[i].transform;
        }
        line.SetUpLine(myList_v);
    }
    void Update()
    {
        myList_1 = spawning.myList;
        Transform[] myList_v = new Transform[myList_1.Count];
        for(int i = 0; i<myList_1.Count; i++)
        {
            
            myList_v[i] = myList_1[i].transform;
        }
        line.SetUpLine(myList_v);
        // line.SetUpLine(points);
    }

    // Update is called once per frame
   
}
