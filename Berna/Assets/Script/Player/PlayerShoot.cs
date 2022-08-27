using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public static PlayerShoot playerShoot;

    public float gunDamage; 
    public float range = 100; 

    public bool playerIsShooting;

    public Camera fpsCam;

  
    public ParticleSystem particleHit;
    public Animator shootAnimator;

    public string id;

    [Header("fire rate")]
    public float fireRate;

    float lastShootTime;


    private void Awake()
    {
        playerShoot = this;
    }

    private void Update()
    {

        if (id == "SMG") 
        {
            if (Input.GetMouseButton(0)) // jadi ini burst shot apa shot terus2an?
            {
                //Raycasthoot();
                Shoot();
                shootAnimator.SetTrigger("shot"); // ini shoot nya 
                playerIsShooting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                playerIsShooting = false;
            }
        }
        if (id == "PISTOL") 
        {
            if (Input.GetMouseButton(0)) 
            {
                Shoot();
                shootAnimator.SetTrigger("PistolShoot");
                playerIsShooting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
            
                playerIsShooting = false;
            }
        }
     
    }
    void Shoot()
    {
        if (playerIsShooting)
        {
            if (Time.time > lastShootTime + fireRate)
            {
                Debug.Log("kena");
                lastShootTime = Time.time;
                rayCasthoot();

            }
        }
        else
        {
            rayCasthoot();
        }

    }
    void rayCasthoot()
    {
        
        particleHit.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetObjectRaycast targetnya = hit.transform.GetComponent<TargetObjectRaycast>();
            if (targetnya != null)
            {
                targetnya.TakeDamage(gunDamage);

            }

            if(hit.transform.tag == "Zombie")
            {
                ZombieAi.shooted();
            }

            //nembak cubenya
            if (hit.transform.tag == "Crane")
            {
                targetnya.craneShot();
            }


        }
      
        
    }

   

   

   

}
