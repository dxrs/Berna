using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;

    public bool gameStarted;
    public bool gameOver;

    private void Awake()
    {
        playerManager = this;
    }
    private void Update()
    {
        if (PlayerDestroy.playerCurrentHealth <= 0.0f) 
        {
            gameOver = true;
            PlayerDestroy.playerCurrentHealth = 0f;
        }
    }
}
