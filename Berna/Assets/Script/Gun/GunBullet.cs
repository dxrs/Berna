using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{

    private void Awake()
    {
        Destroy(gameObject, 3);
    }
    private void Update()
    {
       
    }

}
