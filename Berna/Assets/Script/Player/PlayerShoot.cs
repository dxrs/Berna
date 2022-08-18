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
    public Animator shootAnimator;


    private void Awake()
    {
        playerShoot = this;
    }

    private void Update()
    {

        if (Input.GetButton("Fire1")) // jadi ini burst shot apa shot terus2an?
        {
            shoot();
            shootAnimator.SetTrigger("shot"); // ini shoot nya 
            playerIsShooting = true;
        }
        if (Input.GetButtonUp("Fire1")) 
        {
            playerIsShooting = false;
        }
         

       
     
    }
    void shoot()
    {
        pa.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetObjectRaycast targetnya = hit.transform.GetComponent<TargetObjectRaycast>();
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
