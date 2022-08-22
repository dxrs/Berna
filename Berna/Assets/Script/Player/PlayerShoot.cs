using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public static PlayerShoot playerShoot;

    public float dmg = 10;
    public float range = 100;

    public bool playerIsShooting;

    public Camera fpsCam;

    public ParticleSystem pa;
    public ParticleSystem particleHit;
    public Animator shootAnimator;


    private void Awake()
    {
        playerShoot = this;
    }

    private void Update()
    {

        
        if (Input.GetMouseButton(0)) // jadi ini burst shot apa shot terus2an?
        {
            shoot();
            shootAnimator.SetTrigger("shot"); // ini shoot nya 
            playerIsShooting = true;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            playerIsShooting = false;
        }
         

       
     
    }
    void shoot()
    {
        pa.Play();
        //particleHit.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetObjectRaycast targetnya = hit.transform.GetComponent<TargetObjectRaycast>();
            if(targetnya!= null) 
            {
                targetnya.TakeDamage(dmg);
            }

            if(hit.transform.tag == "Zombie")
            {
                ZombieAi.shooted();
            }

            //nembak cubenya
            if(hit.transform.tag == "Crane")
            {
                targetnya.craneShot();
            }
        }
    }

}
