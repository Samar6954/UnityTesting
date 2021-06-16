using System.Collections.Generic;
using UnityEngine;

public class PolyLine : MonoBehaviour
{
    public List<GameObject> anchors;
    List<Vector3> prevPositions;
    LineRenderer lineRenderer;
    int x=0;

    void Awake()
    {
        this.gameObject.transform.name = "Polyline";
        // this.gameObject.tag = "PolyLine";
        
        // Initializing points
        anchors = new List<GameObject>();
        prevPositions = new List<Vector3>();
        
        // Adding LineRenderer to this gameObject
        this.gameObject.AddComponent<LineRenderer>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Draw only if it gets changed
        if(this.changed)
        {
            lineRenderer.positionCount = anchors.Count;
            Debug.Log(anchors.Count);
            // Draw if enough anchor count
            if (prevPositions.Count >= 2)
                lineRenderer.SetPositions(prevPositions.ToArray());

            // Update previous positions after drawing once
            for(int i=0; i<anchors.Count; i++)
            {
                prevPositions[i] = anchors[i].transform.position;
            }
            x=0;
        }
    }

    // Changed property
    public bool changed
    {
        get
        {
            // Detecting change based on positions
            for(int i=0; i<anchors.Count; i++)
            {
                if(anchors[i].transform.position != prevPositions[i] || x==1)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public void AddAnchor(GameObject anchor)
    {
        anchor.transform.SetParent(this.gameObject.transform);
        anchor.transform.name = "Anchor";
        // anchor.tag = "Anchor";
        anchors.Add(anchor);
        prevPositions.Add(anchor.transform.position + new Vector3(0, 0 ,0.1f));
    }
    
    public void AddAnchorStart(GameObject anchor)
    {
        anchor.transform.SetParent(this.gameObject.transform);
        anchor.transform.name = "Anchor";
        // anchor.tag = "Anchor";
        // anchors.Add(anchor);
        anchors.Insert(0, anchor);
        prevPositions.Insert(0,anchor.transform.position + new Vector3(0, 0 ,0.1f));
    }
     

    public void DeleteAnchor(GameObject anchor)
    {
        Debug.LogWarning("It is better to use DeleteAnchorAt(int index)  or " + 
        "RemoveRangeAnchor(int index, int count) methods, instead of " + 
        "DeleteAnchor(GameObject anchor)", this);

        anchors.Remove(anchor);
        prevPositions.Remove(anchor.transform.position);
        GameObject.Destroy(anchor, 0f);
    }

    public void DeleteAnchorAt(int index)
    {
        GameObject.Destroy(anchors[index], 0f);
        anchors.RemoveAt(index);
        prevPositions.RemoveAt(index);
        x=1;
    }

    public void RemoveRangeAnchor(int index, int count)
    {
        if(index + count >= anchors.Count)
        {
            Debug.LogError(
                "(index + count) is equal to or greater than list size", 
                this);

            return;
        }

        for(int i=index; i<count; i++)
        {
            GameObject.Destroy(anchors[i], 0f);
        }

        anchors.RemoveRange(index, count);
        prevPositions.RemoveRange(index, count);
    }
}