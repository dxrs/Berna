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
        /*
        if (test) 
        {
            if (gameObject != null) 
            {
                ScoreManager.scoreManager.comboScore = 0;
            }
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Block Ground") 
        {
            print("kena");
            test = true;
        }
        if (other.gameObject.name == this.gameObject.name)
        {
            
            if (test) 
            {
                //msh bingung cara deteksi jika trigger/collision blok yg tdk sm
                //ScoreManager.scoreManager.comboScore = 0;
            }
            
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
            //yield return new WaitForSeconds(2);


        }
    }

    private void OnDestroy()
    {
        if (test) 
        {
            //ScoreManager.scoreManager.Scorenya = ScoreManager.scoreManager.Scorenya + ScoreManager.scoreManager.comboScore;
        }
        
    }

}
