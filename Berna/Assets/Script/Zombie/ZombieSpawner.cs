using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner zombieSpawner;
    public GameObject zombies;
    public float posz;
    public float posx;

    public int zombieCount;

    private void Awake()
    {
        zombieSpawner = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.playerManager.gameStarted
            && !PlayerManager.playerManager.gameOver) 
        {
            if (zombieCount < 10)
            {
                StartCoroutine(spawner());
            }
        }
       
    }

    IEnumerator spawner()
    {
        posx = Random.Range(-96, 93);
        posz = Random.Range(-96, 91);
        if (posx < 7 || posx > 14 || posz < 7 || posz > 14)
        {
            Instantiate(zombies, new Vector3(posx, 0.5f, posz), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            zombieCount += 1;

        }
        
       
      
    }
}
