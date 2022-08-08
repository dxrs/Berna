using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public float speed = 1;
    Transform target;

    private int waypointIndex;

    Rigidbody rb;

    bool stop = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        target = Waypoints.points[0];
        StartCoroutine(stopbentar());

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            print(target);
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length -1)
        {
            rb.isKinematic = false;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void getShoot()
    {
        rb.isKinematic = true;
    }

    public IEnumerator stopbentar()
    {
        while (true)
        {
            if(Vector3.Distance(transform.position,target.position)<=0.05f)
            {
                stop = true;
                GetNextWaypoint();
            }
            yield return new WaitForSeconds(1);
            stop = false;
        }
        
    }
}
