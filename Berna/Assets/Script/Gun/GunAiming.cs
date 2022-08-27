using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAiming : MonoBehaviour
{
    public static GunAiming gunAiming;

    [SerializeField] Vector3[] curPos;
    [SerializeField] Vector3[] targetPos;

    [SerializeField] float moveSpeed;

    public bool isAiming;

    private void Awake()
    {
        gunAiming = this;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) 
        {
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            isAiming = false;
        }

        if (isAiming) 
        {
            if (PlayerShoot.playerShoot.id == "SMG") 
            
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos[0], moveSpeed * Time.deltaTime);
            }
            if(PlayerShoot.playerShoot.id == "PISTOL") 
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos[1], moveSpeed * Time.deltaTime);
            }
           
        }
        else 
        {
            if (PlayerShoot.playerShoot.id == "SMG") 
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, curPos[0], moveSpeed * Time.deltaTime);
            }
            if(PlayerShoot.playerShoot.id == "PISTOL") 
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, curPos[1], moveSpeed * Time.deltaTime);
            }

            
        }
    }
}
