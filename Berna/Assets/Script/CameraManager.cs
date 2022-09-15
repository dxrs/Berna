using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager cameraManager;

    [Header("Camera Player Sentivity")]
    public float sensitivity = 800f;
    [SerializeField] Transform playerController;
    public float xRot = 0f;

    [Header("Camera Movement Player Destroy")]
    [SerializeField] Vector3 camMovement;
    [SerializeField] float camRotX;

    private void Awake()
    {
        cameraManager = this;
    }

    private void Update()
    {
        playerSensitvity();
        cameraMovement();
    }

    private void playerSensitvity() 
    {
        if (!PlayerManager.playerManager.gameOver)
        {
            //nilai inputan axis sentifitas mouse
            float Mouse_x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //atas||bawah
            float Mouse_y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; //kiri||kanan

            xRot -= Mouse_y; // nilai rot sentitfitas mouse x di kurangi nilai dari axis mouse y
            xRot = Mathf.Clamp(xRot, -60, 60); //batas nilai rot mouse x untuk lihat ke atas atau bawah cok

            transform.localRotation = Quaternion.Euler(xRot, 0, 0); // rotatsi dari axis mouse x(atas)
            Debug.Log(transform.localRotation);
            playerController.Rotate(Vector3.up * Mouse_x); // rotate dari parent object mengikuti rot mouse x
        }
    }

    private void cameraMovement() //--> pas destroy(sementara pke script)
    {
        if (PlayerManager.playerManager.gameOver) 
        {
            if (Camera.main.fieldOfView < 80f) 
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 80.0f, 3 * Time.deltaTime);
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition, camMovement, 3f * Time.deltaTime);
            transform.localEulerAngles=new Vector3(
                Mathf.Lerp(
                    transform.localEulerAngles.x,camRotX,3f*Time.deltaTime),
                    transform.localEulerAngles.y,
                    transform.localEulerAngles.z);
        }
    }

}
