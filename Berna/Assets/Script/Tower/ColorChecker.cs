using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            //StartCoroutine(ScoreManager.scoreManager.cuk());
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
            Destroy(objnya.gameObject);
            GunController.gunController.curAmmo++;
            ScoreManager.scoreManager.isCombo = true;
       


        }
    }

    private void OnDestroy()
    {
       
        
    }

}
