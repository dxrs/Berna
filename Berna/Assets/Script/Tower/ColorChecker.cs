using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] bool test;

    // Update is called once per frame
    void Update()
    {
        if (test) 
        {
            Destroy(gameObject);
        }
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
        
        while (true)
        {
            yield return new WaitForSeconds(1);
            test = true;
            Destroy(objnya.gameObject);
            
        }
    }

    private void OnDestroy()
    {

        if (test) { GunController.gunController.curAmmo++; }
    }

}
