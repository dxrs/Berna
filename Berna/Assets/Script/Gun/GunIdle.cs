using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdle : MonoBehaviour
{
    public static GunIdle gunIdle;

    float curIdleSpeed= 2f;     
    float curIdlePower= 0.0005f;

    float sprintSpeed=10f;
    float sprintPower=0.0009f;

    Vector3 pos;

    private void Awake()
    {
        if (gunIdle == null) { gunIdle = this; }
    }

   

    private void Update()
    {

        gunSinIdle();

    }

    void gunSinIdle()
    {
        pos = transform.position;
        if (!PlayerShoot.playerShoot.playerIsShooting 
            && !GunAiming.gunAiming.isAiming
            && !PlayerMovement.playerMovement.isSprint) 
        {
           
            transform.position = pos + new Vector3(0.0f,
             Mathf.Sin(curIdleSpeed * Time.time) * curIdlePower,
             0.0f);
        }
        if (PlayerMovement.playerMovement.isSprint
               && !GunAiming.gunAiming.isAiming
               && !PlayerShoot.playerShoot.playerIsShooting)
        {
            transform.position = pos + new Vector3(0.0f,
           Mathf.Sin(sprintSpeed * Time.time) * sprintPower,
           0.0f);


        }
       
       
       
      
       
    }

    
}
