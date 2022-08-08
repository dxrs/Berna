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

    public bool getShot;


    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        blockSpawnPoint = this.gameObject.transform.GetChild(3);
        blokYangDibawa =(GameObject)Instantiate(blocks[Random.Range(0,blocks.Length)],blockSpawnPoint.position,Quaternion.identity);
        blockRB = blokYangDibawa.GetComponent<Rigidbody>();
        target = Waypoints.points[0];
        StartCoroutine(cranePause());
        getShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(blokYangDibawa != null)
        {
            if(blockSpawnPoint != null)
            {
                blokYangDibawa.transform.position = blockSpawnPoint.position;
                blockRB.isKinematic = true;
            }
            else
            {
                blockRB.isKinematic = false;
                blokYangDibawa = null;
            }
        }
        if(!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed *Time.deltaTime);
            
        }
    }
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            if(blokYangDibawa != null)
            {
                blockRB.isKinematic = false;
                Destroy(gameObject);
                Destroy(blokYangDibawa.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            return;
        }        
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void destroyCrane()
    {
        Destroy(blockSpawnPoint.gameObject);
    }

    public IEnumerator cranePause()
    {
        while (true)
        {
            if(transform.position == target.position)
            {
                stop = true;
                GetNextWaypoint();
            }
            yield return new WaitForSeconds(1f);
            stop = false;

        }
    }

}
