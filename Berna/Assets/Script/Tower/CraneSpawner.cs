using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneSpawner : MonoBehaviour
{
    public Transform crane;
    public Transform spawnpoint;

    public float timeToSpawn;
    private float countDown = 2f;

    public GameObject[] blocks;
  
    
    void Start()
    {
        //StartCoroutine(spawn());
    }
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

    public IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(blocks[Random.Range(0,blocks.Length)],spawnpoint.position,Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
