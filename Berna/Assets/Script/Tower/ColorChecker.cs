using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] bool test;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(blok());
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
        
        while (true)
        {
            yield return new WaitForSeconds(1);
            test = true;
            Destroy(gameObject);
            Destroy(objnya.gameObject);
            
        }
    }
    IEnumerator blok() 
    {
        if (test) 
        {
            
            GunController.gunController.curAmmo++;
            yield return new WaitForSeconds(0.1f);
            test = false;
            
        }
        
    }

    private void OnDestroy()
    {

        if (test) {  }
    }

}
