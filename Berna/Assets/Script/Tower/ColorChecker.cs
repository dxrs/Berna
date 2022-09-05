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
        while (true)
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
            Destroy(objnya.gameObject);
            GunController.gunController.curAmmo++;
        }
    }

    private void OnDestroy()
    {

        if (test) {  }
    }

}
