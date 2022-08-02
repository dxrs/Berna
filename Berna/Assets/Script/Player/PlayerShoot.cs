using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float powerToShoot;
    [SerializeField] int curBullet;
    [SerializeField] GameObject bulletnya;

    public Transform muzzle;
    public int maxBullet;


    private void Update()
    {
        //contoh samplenya
        
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            GameObject spawnBullet = Instantiate(bulletnya,
                                muzzle.position,
                                muzzle.rotation
                                );
            spawnBullet.GetComponent<Rigidbody>().velocity = muzzle.forward * powerToShoot;

        }
    }

}
