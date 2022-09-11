using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    private void Update()
    {
        if (PlayerManager.playerManager.gameOver)
        {
            Destroy(gameObject);
            InGameUI.inGameUI.timeEnd();
        }
    }

    private void OnDestroy()
    {
       
    }
}
