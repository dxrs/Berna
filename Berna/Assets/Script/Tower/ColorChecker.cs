using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(this.gameObject);
            Destroy(objnya.gameObject);
            
        }
    }

    private void OnDestroy()
    {
        if (gameObject == null) 
        {
            GunController.gunController.curAmmo++;
        }
    }

}
