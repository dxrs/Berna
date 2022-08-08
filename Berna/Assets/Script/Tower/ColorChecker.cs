using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    Collision objekTersentuh;
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
            objekTersentuh = col;
            StartCoroutine("startDestroying");
        }
    }

    IEnumerator startDestroying()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
            Destroy(objekTersentuh.gameObject);
        }
        
    }

}
