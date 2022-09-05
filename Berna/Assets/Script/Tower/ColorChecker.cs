using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] bool test;
    

    //konflik
    // peluru +2
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Block Ground") 
        {
            print("kena");
            test = true;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == this.gameObject.name)
        {
            StartCoroutine(startDestroying(col.gameObject));

        }
    }
    

    IEnumerator startDestroying(GameObject objnya)
    {
        
        //StartCoroutine(blok());
        while (true)
        {
            yield return new WaitForSeconds(10);
            
            Destroy(gameObject);
            Destroy(objnya.gameObject);
            

        }
        
    }
    /*
    IEnumerator blok()
    {
        test = true;
        if (test)
        {
            
            GunController.gunController.curAmmo++;
            yield return new WaitForSeconds(0.0001f);
            test = false;

        }

    }
    */

    private void OnDestroy()
    {

        if (test) { GunController.gunController.curAmmo++; }
    }

}
