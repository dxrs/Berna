using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;

    public bool gameStarted;
    public bool gameOver;

    [SerializeField] BoxCollider physicsGround;

    private void Awake()
    {
        playerManager = this;
    }
    private void Update()
    {
        if (InGameUI.inGameUI.playerHealth <= 0.0f) 
        {
            gameOver = true;
            InGameUI.inGameUI.playerHealth = 0.0f;
        }

        if (gameOver) 
        {
            physicsGround.enabled = true;
        }
    }
}
