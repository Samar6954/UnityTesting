using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Control_Points : MonoBehaviour
{
    GameObject Curve;
    public List<GameObject> anchors_curve;
    public List<GameObject> control_points_1;
    public List<GameObject> control_points_2;
    GameObject control_point_1;
    GameObject control_point_2;
    GameObject curve_GO;
    public List<GameObject> bezier_list;
    int prev;
    int once;
    void Start()
    {
        Curve = GameObject.Find("Polyline");
        anchors_curve = Curve.GetComponent<PolyLine>().anchors;
        prev = anchors_curve.Count;
        control_points_1 = new List<GameObject>();
        control_points_2 = new List<GameObject>();
        // bezier_list = new List<GameObject>();
        control_point_1 = new GameObject();
        control_point_2 = new GameObject();
        curve_GO = new GameObject("Curveline");
        curve_GO.AddComponent<CurveLine>(); 
        // Curve = GameObject.Find("Polyline");      
    }

    void Update()
    {
        // anchors_curve = Curve.GetComponent<PolyLine>().anchors;
        if(anchors_curve.Count > prev && anchors_curve.Count > 1)
        {
            control_point_1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            control_point_1.transform.localScale = 
                new Vector3 (0.5f, 0.5f, 0.5f);
            control_points_1.Add(control_point_1);
            control_point_2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            control_point_2.transform.localScale = 
                new Vector3 (0.5f, 0.5f, 0.5f);
            control_points_2.Add(control_point_2);
            prev = anchors_curve.Count;
        }
        // prev = anchors_curve.Count;
        if(anchors_curve.Count == 2)
        {
            Vector3 current_point_1st = anchors_curve[0].transform.position;
            Vector3 current_point_2nd = anchors_curve[1].transform.position;

            Vector3 points_dist_first = current_point_1st - current_point_2nd;

            Vector3 angle_first = current_point_2nd - current_point_1st;

            control_points_1[0].transform.position = 
                new Vector3(current_point_2nd.x+(points_dist_first.magnitude/3)*
                (angle_first.normalized.x*-1), current_point_2nd.y+
                (points_dist_first.magnitude/3)*angle_first.normalized.y,0);
            control_points_2[0].transform.position = 
                new Vector3(current_point_1st.x+(points_dist_first.magnitude/3)*
                (angle_first.normalized.x), current_point_1st.y+
                (points_dist_first.magnitude/3)*angle_first.normalized.y , 0);
        }
        else if(anchors_curve.Count>2)
        {
            Vector3 current_point_1st = anchors_curve[0].transform.position;
            Vector3 current_point_2nd = anchors_curve[1].transform.position;
            Vector3 next_point_first = anchors_curve[2].transform.position;

            Vector3 points_dist_first = current_point_1st - current_point_2nd;
            // Debug.Log(anchors_curve[2]);
            Vector3 angle_first = current_point_2nd - next_point_first;

            control_points_1[0].transform.position = 
                new Vector3(current_point_2nd.x+(points_dist_first.magnitude/3)*
                angle_first.normalized.x, current_point_2nd.y+
                (points_dist_first.magnitude/3)*angle_first.normalized.y , 0);
            control_points_2[0].transform.position = 
                new Vector3(current_point_1st.x+(points_dist_first.magnitude/3)*
                (angle_first.normalized.x*-1), current_point_1st.y+
                (points_dist_first.magnitude/3)*angle_first.normalized.y , 0);
        }

        if(anchors_curve.Count>3)
        {
            for (int i=0; i<anchors_curve.Count-3; i++)
            {
                Vector3 prev_point = anchors_curve[i].transform.position;
                Vector3 current_point_1 = anchors_curve[i+1].transform.position;
                Vector3 current_point_2 = anchors_curve[i+2].transform.position;
                Vector3 next_point = anchors_curve[i+3].transform.position; 
                
                Vector3 points_dist = current_point_1 - current_point_2;
                // Debug.Log(points_dist.magnitude);

                Vector3 angle = current_point_2 - next_point;
                Vector3 angle_2 = current_point_1 - prev_point;
                // Debug.Log(angle_2.normalized);

                
                control_points_1[i+1].transform.position = 
                    new Vector3(current_point_2.x+(points_dist.magnitude/3)*
                    angle.normalized.x, current_point_2.y+
                    (points_dist.magnitude/3)*angle.normalized.y , 0);
                control_points_2[i+1].transform.position = 
                    new Vector3(current_point_1.x+(points_dist.magnitude/3)*
                    angle_2.normalized.x, current_point_1.y+
                    (points_dist.magnitude/3)*angle_2.normalized.y , 0);  
            } 
        } 
        if(anchors_curve.Count>2)
        {
        Vector3 prev_point_last = 
            anchors_curve[anchors_curve.Count-3].transform.position;
        Vector3 current_point_last = 
            anchors_curve[anchors_curve.Count-2].transform.position;
        Vector3 current_point_last_2 = 
            anchors_curve[anchors_curve.Count-1].transform.position;
        

        Vector3 points_dist_last = current_point_last - current_point_last_2;
        // Debug.Log(anchors_curve[2]);
        Vector3 angle_last = current_point_last - prev_point_last;

        control_points_1[control_points_1.Count-1].transform.position = 
            new Vector3(current_point_last_2.x+(points_dist_last.magnitude/3)*
            (angle_last.normalized.x*-1), current_point_last_2.y+
            (points_dist_last.magnitude/3)*angle_last.normalized.y , 0);
        control_points_2[control_points_2.Count-1].transform.position = 
            new Vector3(current_point_last.x+(points_dist_last.magnitude/3)*
            (angle_last.normalized.x), current_point_last.y+
            (points_dist_last.magnitude/3)*angle_last.normalized.y , 0);
        }
    
    if(Input.GetMouseButtonDown(1))
    {
        bezier_list = new List<GameObject>();
    for(int i=0; i<anchors_curve.Count-1; i++)
    {
        bezier_list.Add(anchors_curve[i]);
        bezier_list.Add(control_points_2[i]);
        bezier_list.Add(control_points_1[i]);
    }
    if(anchors_curve.Count>1)
    {
        bezier_list.Add(anchors_curve[anchors_curve.Count-1]);
    }
    
    }
    curve_GO.GetComponent<CurveLine>().MakeLine(bezier_list);
    }
}