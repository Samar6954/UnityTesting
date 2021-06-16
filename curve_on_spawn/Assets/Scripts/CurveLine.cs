using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveLine : MonoBehaviour
{

    LineRenderer lineRender;
    List<Vector3> curve_points;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<LineRenderer>();
        lineRender = GetComponent<LineRenderer>();
        lineRender.SetWidth(0.6f, 0.6f);
        lineRender.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        // lineRender.positionCount = anchors.Count;
    }

    public void MakeLine(List<GameObject> anchors)
    {
        curve_points = new List<Vector3>();
        if (anchors == null && (anchors.Count>1))
            return ; 

        List<Vector3> temp = new List<Vector3>();
        
        for(int j=0; j<anchors.Count-3; j+=3)
        {
            for(int i=1; i<10; i++)
            {
                
                Vector3 p1 = anchors[j].transform.position;
                Vector3 p2 = anchors[j+1].transform.position;
                Vector3 p3 = anchors[j+2].transform.position;
                Vector3 p4 = anchors[j+3].transform.position;

                Vector3 A = Vector3.Lerp(p1,p2, i*0.1f);
                Vector3 B = Vector3.Lerp(p2,p3, i*0.1f);
                Vector3 C = Vector3.Lerp(p3,p4, i*0.1f);

                Vector3 D = Vector3.Lerp(A,B, i*0.1f);
                Vector3 E = Vector3.Lerp(B,C, i*0.1f);

                Vector3 F = Vector3.Lerp(D,E, i*0.1f);

                curve_points.Add(F);
            }
        }

        
        // if (curve_points != null)
        // {
        // for(int i=0; i<curve_points.Count; i++)
        // {
        //     temp.Add(curve_points[i]);
        // }
        // }
        // temp = anchors.transform.position;
        
        if (anchors.Count >= 2)
        {
            lineRender.positionCount = curve_points.Count;
            lineRender.SetPositions(curve_points.ToArray());
            // Debug.Log(anchors.Count);
        }

            // for(int i=0; i<anchors.Count; i++)
            // {
            //     temp.Add(anchors[i].transform.position);
            // }
            // // temp = anchors.transform.position;
            
            // if (anchors.Count >= 2)
            // {
            //     lineRender.positionCount = temp.Count;
            //     lineRender.SetPositions(temp.ToArray());
            //     // Debug.Log(anchors.Count);
            // }
            
        
    }
}
