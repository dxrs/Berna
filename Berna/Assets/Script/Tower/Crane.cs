using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{

    public float speed =0.1f;
    Transform target;

    private int waypointIndex = 0;

    public GameObject[] blocks;
    GameObject blokYangDibawa;
    Rigidbody blockRB;
    Transform blockSpawnPoint;

    B_colorChanger boxColor;

    public bool shotEnable;
    bool stop = false;



    void Start()
    {
        blockSpawnPoint = this.gameObject.transform.GetChild(3);
        blokYangDibawa =(GameObject)Instantiate(blocks[Random.Range(0,blocks.Length)],blockSpawnPoint.position,Quaternion.identity);
        blockRB = blokYangDibawa.GetComponent<Rigidbody>();
        boxColor = blokYangDibawa.GetComponent<B_colorChanger>();
        target = Waypoints.points[0];
        StartCoroutine(cranePause());
    }

    void Update()
    {
        onShot();

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

    void onShot()
    {
        shotEnable = boxColor.ready;
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
