using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetObjectRaycast : MonoBehaviour
{


    public float nyawa = 50f;
    float MaxNyawaZombie = 100;

    [Header("Crane and Box")]
    public GameObject blockSpot;
    Collider bxcollider;

    [Header("Zombie")]
    public Image BarImage;

  
    void Update()
    {
        zombieHealth();
    }

    public void TakeDamage(float amount) 
    {
        nyawa -= amount * Time.deltaTime;
        if (nyawa <= 0) { die(); }
    }

    void die() 
    {
        Destroy(gameObject);
        ZombieSpawner.zombieCount -=1;
    }

    void zombieHealth()
    {
        if(BarImage == null)
        {
            return;
        }
        else
        {
            BarImage.fillAmount = nyawa/MaxNyawaZombie;
        }
    }

    public void craneShot()
    {
        bxcollider = gameObject.GetComponent<BoxCollider>();
        bxcollider.enabled = false;
        Destroy(blockSpot);
    }
}
