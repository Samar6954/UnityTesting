using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Control_Points : MonoBehaviour
{
    GameObject Curve;
    public List<GameObject> anchors_curve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Curve = GameObject.Find("Polyline");
        anchors_curve = Curve.GetComponent<PolyLine>().anchors;
    }
}
