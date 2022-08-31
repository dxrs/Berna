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
            if (Input.GetMouseButtonDown(0)) // jadi ini burst shot apa shot terus2an?
            {
                shootAnimator.SetBool("SMG_sht",true);
                playerIsShooting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                shootAnimator.SetBool("SMG_sht",false);
                playerIsShooting = false;
            }
        }
        if (id == "PISTOL") 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                shootAnimator.SetBool("sht",true);
                playerIsShooting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                shootAnimator.SetBool("sht",false);
                playerIsShooting = false;
            }
        }
     
    }
   
    void rayCasthoot()
    {
        AudioScript.instance.SMG_Sound();
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

            Z_Hitted hitZombie = hit.transform.GetComponentInChildren<Z_Hitted>();
            if(hit.transform.tag == "Zombie")
            {
                hitZombie.shooted();
            }

            //nembak cubenya
            if (hit.transform.tag == "Crane")
            {
                targetnya.craneShot();
            }


        }
    }
}
