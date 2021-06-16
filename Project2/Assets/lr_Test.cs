using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_Test : MonoBehaviour
{

    [SerializeField] private Transform[] points;
    // private Transform[] points = spawning.myList.ToArray();
    [SerializeField] private lr_LineControl line;
    // Start is called before the first frame update
    void Start()
    {
        line.SetUpLine(points);
    }
    void Update()
    {
        line.SetUpLine(points);
    }

    // Update is called once per frame
   
}
