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
    bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        blockSpawnPoint = this.gameObject.transform.GetChild(3);
        blokYangDibawa =(GameObject)Instantiate(blocks[Random.Range(0,blocks.Length)],blockSpawnPoint.position,Quaternion.identity);
        blockRB = blokYangDibawa.GetComponent<Rigidbody>();
        target = Waypoints.points[0];
        StartCoroutine(cranePause());
    }

    // Update is called once per frame
    void Update()
    {
        if(blokYangDibawa != null)
        {
            blokYangDibawa.transform.position = blockSpawnPoint.position;
            blockRB.isKinematic = true;
        }
        if(!stop)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
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

    public IEnumerator cranePause()
    {
        while (true)
        {
            if(Vector3.Distance(transform.position,target.position)<=0.05f)
            {
                stop = true;
                GetNextWaypoint();
            }
            yield return new WaitForSeconds(0.5f);
            stop = false;

        }
    }

}
