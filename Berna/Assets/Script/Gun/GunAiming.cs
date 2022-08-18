using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAiming : MonoBehaviour
{
    public static GunAiming gunAiming;

    Vector3 curPos = new Vector3(0.341f, -0.245f, -0.24f);
    Vector3 targetPos = new Vector3(0f, -0.081f, -0.225f);

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
            //transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            isAiming = false;
           // transform.localPosition = Vector3.Lerp(targetPos, transform.localPosition, moveSpeed * Time.deltaTime);
        }

        if (isAiming) 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
        else 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, curPos, moveSpeed * Time.deltaTime);
        }
    }
}
