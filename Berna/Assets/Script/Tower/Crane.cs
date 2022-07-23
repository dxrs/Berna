using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float speed =0.3f;
    Transform target;

    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position -transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position)<=0.3f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }        
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

}
