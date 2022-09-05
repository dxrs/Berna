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

            Destroy(gameObject);
            Destroy(objnya.gameObject);
            

        }
        
    }


    private void OnDestroy()
    {

        if (test) {  }
    }

}
