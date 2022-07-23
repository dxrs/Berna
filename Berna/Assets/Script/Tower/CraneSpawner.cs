using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneSpawner : MonoBehaviour
{
    public Transform crane;
    public Transform spawnpoint;

    public float timeToSpawn;
    private float countDown = 2f;
  

    // Update is called once per frame
    void FixedUpdate()
    {
        if(countDown <= 0)
        {
            spawnCrane();
            countDown = timeToSpawn;
        }
        countDown-=Time.deltaTime;
    }

    void spawnCrane()
    {
        Instantiate(crane,spawnpoint.position,Quaternion.identity);
    }
}
