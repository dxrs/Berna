using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float dmg = 10;
    public float range = 100;

    public Camera fpsCam;

    public ParticleSystem pa;


    private void Update()
    {
        //contoh samplenya


        if (Input.GetButtonDown("Fire1")) 
        {
            shoot();
        }
       
        
    }
    void shoot()
    {
        pa.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target targetnya = hit.transform.GetComponent<target>();
            if(targetnya!= null) 
            {
                targetnya.TakeDamage(dmg);
            }

            //nembak cubenya
            if(hit.transform.tag == "Crane")
            {
                targetnya.craneShot();
            }
        }
    }

}
