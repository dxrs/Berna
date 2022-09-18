using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombies;
    public float posz;
    public float posx;

    public static int zombieCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.playerManager.gameStarted) 
        {
            if (zombieCount < 10)
            {
                StartCoroutine(spawner());
            }
        }
        
    }

    IEnumerator spawner()
    {
        posx = Random.Range(-96,93);
        posz = Random.Range(-96,91);
        if(posx<7 || posx>14 || posz<7 || posz>14)
        {
            Instantiate(zombies,new Vector3(posx,0.5f,posz),Quaternion.identity);
            zombieCount += 1;
        }
        yield return new WaitForSeconds(1f);
    }
}
