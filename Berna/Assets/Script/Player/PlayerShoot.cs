using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public static PlayerShoot playerShoot;

    public float gunDamage; 
    public float range; 

    public bool playerIsShooting;

    public Camera fpsCam;

  
    public ParticleSystem particleHit;
    public Animator shootAnimator;

    public GameObject[] guns;

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
            if (Input.GetMouseButton(0)) 
            {
          
                Shoot();
                shootAnimator.SetTrigger("shot"); 
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
    void rayCasthoot()
    {
        
        particleHit.Play();
        if (playerIsShooting)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                TargetObjectRaycast targetnya = hit.transform.GetComponent<TargetObjectRaycast>();
                if (targetnya != null)
                {
                    targetnya.TakeDamage(gunDamage);

                }

                
                if (hit.transform.tag == "Crane")
                {
                    targetnya.craneShot();
                }


            }
        }
        
    }

    void Shoot() 
    {
        if (Time.time > lastShootTime + fireRate) 
        {
            Debug.Log("kena");
            lastShootTime = Time.time;
            rayCasthoot();
           
        }
    }

   

   

}
