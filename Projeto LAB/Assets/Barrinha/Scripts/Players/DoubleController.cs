using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleController : MonoBehaviour
{
    [SerializeField] DistanceJoint2D d1, d2;
    [SerializeField] PlayerMovement1 pl1;
    [SerializeField] PlayerMovement2 pl2;
    //
    public enum DistanceModes
    {
        MIN_DISTANCE = 0,
        MAX_DISTANCE = 1,

    }    
    
    void Update()
    {
        //float dist = Vector2.Distance(pl1.transform.position, pl2.transform.position);
        //Debug.Log(dist);
        //if (dist < 2)
        //{            
        //    d1.distance = dist;
        //    d2.distance = dist;
        //}
        //else if (dist > 2)
        //{
        //    d1.distance = (float)DistanceModes.MAX_DISTANCE;
        //    d2.distance = (float)DistanceModes.MAX_DISTANCE;

        //}


    }
}
