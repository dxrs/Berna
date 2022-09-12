using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivotManager : MonoBehaviour
{


    public GameObject test;
    private Rigidbody rb;
    private BoxCollider bc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        
        if (PlayerManager.playerManager.gameOver) 
        {
            gameObject.transform.parent = test.transform.parent;
            rb.isKinematic = false;
            bc.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            PlayerManager.playerManager.gameOver = true;
            
        }
    }
    
}
