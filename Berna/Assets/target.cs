using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float nyawa = 50f;

    public void TakeDamage(float amount) 
    {
        nyawa -= amount;
        if (nyawa <= 0) { die(); }
    }

    void die() 
    {
        Destroy(gameObject);
    }
}
