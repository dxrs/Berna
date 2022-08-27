using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    int hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(hitPlayer<1)
            {
                PlayerDestroy.playerCurrentHealth-=10;
                hitPlayer++;
            }
            else
            {
                hitPlayer=0;
            }
        }
    }
}
