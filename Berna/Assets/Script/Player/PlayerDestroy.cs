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

    private void OnDestroy()
    {
        if (PlayerManager.playerManager.gameOver)
        {
            Destroy(gameObject);
            InGameUI.inGameUI.timeEnd();
        }
    }
}
