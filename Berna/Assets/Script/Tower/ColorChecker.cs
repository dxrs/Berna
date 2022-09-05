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
<<<<<<< HEAD
        StartCoroutine(blok());
=======
       
>>>>>>> Zaa
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == gameObject.name) 
        {
            
            
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == this.gameObject.name)
        {
            StartCoroutine(startDestroying(col));

        }
    }
    

    IEnumerator startDestroying(Collision objnya)
    {
        
        //StartCoroutine(blok());
        while (true)
        {
            yield return new WaitForSeconds(1);
<<<<<<< HEAD
            test = true;
=======
            
>>>>>>> Zaa
            Destroy(gameObject);
            Destroy(objnya.gameObject);
            

        }
        
    }
<<<<<<< HEAD
    IEnumerator blok() 
    {
        if (test) 
        {
            
            GunController.gunController.curAmmo++;
            yield return new WaitForSeconds(0.1f);
            test = false;
            
        }
        
    }
=======
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
>>>>>>> Zaa

    private void OnDestroy()
    {

        if (test) {  }
    }

}
