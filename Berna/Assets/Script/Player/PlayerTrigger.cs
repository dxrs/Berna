using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorTrigger;

    private void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Door Trigger") 
        {
            PlayerManager.playerManager.gameStarted = true;
            InGameUI.inGameUI.timeStart();
            Destroy(doorTrigger);
        }
    }
}
