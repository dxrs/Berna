using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    float playerMaxHealth = 100;

    public static float playerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerCurrentHealth);
        //demaged();
    }

    public static void demaged()
    {
        
    }
}
