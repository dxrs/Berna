using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdle : MonoBehaviour
{
    public static GunIdle gunIdle;

    [SerializeField] float idleSpeed;
    [SerializeField] float idlePower;

    Vector3 pos;

    private void Awake()
    {
        if (gunIdle == null) { gunIdle = this; }
    }

   

    private void Update()
    {

        IDLE();

    }

    void IDLE()
    {
        if (!PlayerShoot.playerShoot.playerIsShooting && !GunAiming.gunAiming.isAiming) 
        {
            pos = transform.position;
            transform.position = pos + new Vector3(0.0f,
             Mathf.Sin(idleSpeed * Time.time) * idlePower,
             0.0f);
        }
       
      
       
    }

    
}
