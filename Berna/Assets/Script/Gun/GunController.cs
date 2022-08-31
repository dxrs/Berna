using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController gunController;

    [Header("Gun Controller Required Variable atau Value")]
    public Camera cam;
    public Transform gunPivot;
    public Animator gunAnim;
    public bool isPlayershot;
    public ParticleSystem gunMuzzle;

    [Header("Gun ID")]
    [SerializeField]
    [Tooltip("ID senjata nanti di panggil ke playerGun samakan nilai array yang di playerGun untuk swap weapon")]
    [Range(0, 4)]
    public int id;


    [Header("Gun Spec")]
    [SerializeField] float shootRange;
    [SerializeField] float gunDamage;

    [Header("Gun Idle")]
    [SerializeField] float curIdleSpeed;
    [SerializeField] float curIdlePower;
    [SerializeField] float curSprintSpeed;
    [SerializeField] float curSprintPower;
    Vector3 pos;

    [Header("Gun Sway")]
    [SerializeField]
    [Range(1, 5)]
    float intensity;
    [SerializeField]
    [Range(5, 15)]
    float smooth;
    bool isGunSway;
    Quaternion originRotPoint;

    [Header("Gun Aiming")]
    public bool isAiming;
    [SerializeField] Vector3 defaultPos;
    [SerializeField] Vector3 aimingPos;
    [Tooltip("kecepatan pindah dari defaultPos ke aimPos dan sebaliknya")]
    [SerializeField] float movementAimPosSpeed;
    [Tooltip("zoom pada saat aim pke fov dari camera")]
    [SerializeField] float aimFov;
    [Tooltip("default fov pas lagi tidak aim")]
    [SerializeField] float defaultFov;
    

    private void Awake()
    {
        gunController = this;
    }

    private void Start()
    {
        originRotPoint = gunPivot.transform.localRotation;
    }


    private void Update()
    {
        gunShoot();
        gunSway();
        gunAiming();
        gunIdle(); // sementara
    }

    private void FixedUpdate()
    {
        // gun idleSpeed jika di panggil di sini ada bug klo nilainya smkin rendah
        //gunIdle(); 
    }

    public void gunShoot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            gunAnim.SetBool("sht", true);
            isPlayershot = true;
        }
       
        
        if (Input.GetMouseButtonUp(0))
        {
            gunAnim.SetBool("sht", false);
            isPlayershot = false;
            
        }
    }

    void rayCastHitShoot()
    {
        AudioScript.instance.SMG_Sound();
        gunMuzzle.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,
         cam.transform.forward,
         out hit,
         shootRange))
        {
            Debug.DrawLine(cam.transform.position, hit.transform.position, Color.red);
            Debug.Log(hit.transform.name);
            TargetObjectRaycast shootTarget =
                   hit.transform.GetComponent<TargetObjectRaycast>();
            if (shootTarget != null)
            {
                shootTarget.TakeDamage(gunDamage);
            }

            Z_Hitted hitZombie = hit.transform.GetComponentInChildren<Z_Hitted>();
            if (hit.transform.tag == "Zombie")
            {
                hitZombie.shooted();
            }

            //nembak cubenya
            if (hit.transform.tag == "Crane")
            {
                shootTarget.craneShot();
            }

        }
    }

    void gunAiming() 
    {
        if (Input.GetMouseButton(1)) 
        {
            
            isAiming = true;    
        }
        else if (Input.GetMouseButtonUp(1))
        {
           
            isAiming = false;
        }

        if (isAiming) 
        {
            gunPivot.transform.localPosition = Vector3.Lerp(
                gunPivot.transform.localPosition, aimingPos,
                movementAimPosSpeed * Time.deltaTime);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, aimFov,
                movementAimPosSpeed * Time.deltaTime);
        }
        else 
        {
            gunPivot.transform.localPosition = Vector3.Lerp(
               gunPivot.transform.localPosition, defaultPos,
               movementAimPosSpeed * Time.deltaTime);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFov,
                movementAimPosSpeed * Time.deltaTime);
        }
    }

    void gunSway() 
    {
        if(Input.GetAxis("Mouse X")==0 &&
            Input.GetAxis("Mouse Y") == 0) 
        {
            isGunSway = false;
        }
        else 
        {
            isGunSway = true;
        }

        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        Quaternion sway_X = Quaternion.AngleAxis(intensity * mouse_X, Vector3.up);
        Quaternion sway_Y = Quaternion.AngleAxis(intensity * mouse_Y, Vector3.right);
        Quaternion targetRot = originRotPoint * sway_X * sway_Y;

        gunPivot.transform.localRotation = Quaternion.Lerp(gunPivot.transform.localRotation, targetRot, Time.deltaTime * smooth);
    }

    void gunIdle()  //--> bakal di tambah pas player jalan(tidak sprint)
    {
        pos = gunPivot.transform.position;

        // idle pas diem
        if(!isPlayershot&&
            !isAiming&&
            !PlayerMovement.playerMovement.isSprint&&
             PlayerMovement.playerMovement.isInGround) 
        {
            gunPivot.transform.position = pos + new Vector3(0.0f,
                Mathf.Sin(curIdleSpeed * Time.time) * curIdlePower,
                0.0f);
        }

        //idle pas sprint
        if(!isPlayershot&&
            !isAiming
            && PlayerMovement.playerMovement.isSprint&&
             PlayerMovement.playerMovement.isInGround) 
        {
            gunPivot.transform.position = pos + new Vector3(0.0f,
               Mathf.Sin(curSprintSpeed * Time.time) * curSprintPower,
               0.0f);
        }
    }


}
