using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] bool test;

    // Update is called once per frame
    void Update()
    {
       
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
            StartCoroutine(startDestroying(col.gameObject));

        }
    }
    

    IEnumerator startDestroying(GameObject objnya)
    {
        
        //StartCoroutine(blok());
        while (true)
        {
            yield return new WaitForSeconds(1);
            
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
