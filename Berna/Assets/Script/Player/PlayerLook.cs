using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
   

    public float sensitivity; // sensitivity mouse

    [SerializeField] Transform playerBody;

    float xRot = 0f;

    
    private void Update()
    {
        lookAround();
    }

    void lookAround() 
    {
        float Mouse_x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float Mouse_y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRot -= Mouse_y;
        xRot = Mathf.Clamp(xRot, -60, 60);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        playerBody.Rotate(Vector3.up * Mouse_x);
    }
}
