using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Points;

    private void Awake()
    {
        List<Transform> children = new List<Transform>();        
        foreach (Transform cur in transform)
        {
                children.Add(cur);
        }

        Points = children.ToArray();
    }
    private void OnDrawGizmosSelected()
    {
        Transform prev = null;
        Gizmos.color = Color.green;
        foreach(Transform cur in transform)
        {
            if (prev != null && cur != transform)
            {
                Gizmos.DrawLine(prev.position, cur.position);
            }
            prev = cur;
        }
        
    }
}
