using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdle : MonoBehaviour
{
    public static GunIdle gunIdle;

    [SerializeField] float idleSpeed;
    [SerializeField] float idlePower;

    Vector3 pos;

    private void Awake()
    {
        if (gunIdle == null) { gunIdle = this; }
    }

    private void Start()
    {
        
        
    }

    private void Update()
    {

        IDLE();
        //print(transform.position);
    }

    void IDLE()
    {
        pos = transform.position;
        transform.position = pos + new Vector3(0.0f,
         Mathf.Sin(idleSpeed * Time.time) * idlePower,
         0.0f);
        if (!GunSway.gunSway.isSwaying) 
        {
         
        }
       
    }

    
}
