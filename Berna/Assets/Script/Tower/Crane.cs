using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float speed =0.05f;
    Transform target;

    private int waypointIndex = 0;

    public GameObject[] blocks;
    GameObject blokYangDibawa;
    Rigidbody blockRB;
    Transform blockSpawnPoint;

    float curentCountdown = 2;
    // Start is called before the first frame update
    void Start()
    {
        blockSpawnPoint = this.gameObject.transform.GetChild(3);
        blokYangDibawa =(GameObject)Instantiate(blocks[Random.Range(0,blocks.Length)],blockSpawnPoint.position,Quaternion.identity);
        blockRB = blokYangDibawa.GetComponent<Rigidbody>();
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(blokYangDibawa != null)
        {
            blokYangDibawa.transform.position = blockSpawnPoint.position;
            blockRB.isKinematic = true;
        }
        else
        {
            return;
        }
        
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
            blockRB.isKinematic = false;
            Destroy(gameObject);
            return;
        }        
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        
    }

}
