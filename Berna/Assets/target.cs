using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float nyawa = 50f;
    public GameObject blockSpot;
    Collider bxcollider;

    public void TakeDamage(float amount) 
    {
        nyawa -= amount;
        if (nyawa <= 0) { die(); }
    }

    void die() 
    {
        Destroy(gameObject);
    }

    public void craneShot()
    {
        bxcollider = gameObject.GetComponent<BoxCollider>();
        bxcollider.enabled = false;
        Destroy(blockSpot);
    }
}
