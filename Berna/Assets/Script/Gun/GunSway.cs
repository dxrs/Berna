using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    public static GunSway gunSway;

    public float intensity;
    public float smooth;

    public bool isSwaying;

    Quaternion originRot;

    private void Awake()
    {
        if (gunSway == null) { gunSway = this; }
    }
    private void Start()
    {
        originRot = transform.localRotation;
    }

    private void Update()
    {
        /*
        if(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) 
        {
            isSwaying = false;
        }
       
        else { isSwaying = true; }
         */
        float xMmouse = Input.GetAxis("Mouse X");
        float yMmouse = Input.GetAxis("Mouse Y");


        Quaternion xSway = Quaternion.AngleAxis(intensity * xMmouse, Vector3.up);
        Quaternion ySway = Quaternion.AngleAxis(intensity * yMmouse, Vector3.right);
        Quaternion targetRot = originRot * xSway * ySway;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, Time.deltaTime * smooth);
    }
}
