using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Door Trigger") 
        {
            InGameUI.inGameUI.timeStart();
            Destroy(doorTrigger);
        }
    }
}
