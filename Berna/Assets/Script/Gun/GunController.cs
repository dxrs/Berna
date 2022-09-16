using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunController : MonoBehaviour
{
    public static GunController gunController;

    [Header("Gun Controller Required Variable atau Value")]
    public Camera cam;
    public Transform gunPivot;
    public Animator gunAnim;
    private bool isPlayershot;
    [SerializeField] ParticleSystem gunMuzzle;

    [Header("Gun ID")] //--> bakal kepake nanti
    [SerializeField]
    [Tooltip("ID senjata nanti di panggil ke playerGun samakan nilai array yang di playerGun untuk swap weapon")]
    [Range(0, 4)]
    public int id;


    [Header("Gun Spec")]
    [SerializeField] float shootRange;
    [SerializeField] float gunDamage;
    [SerializeField] TextMeshProUGUI tmp_curAmmo;
    public int curAmmo;
    public int gunAmmo;


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

    [Header("Recoil")]
    public float snappiness;
    public float returnAmount;
    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;
    [SerializeField] float aimRecoilX;
    [SerializeField] float aimRecoilY;
    [SerializeField] float aimRecoilZ;
    [SerializeField] float backToZ;
    Vector3 targetRot, curRot, targetPos, curPos, gunPos;

   


    private void Awake()
    {
        if (gunController == null) gunController = this;
        
    }

    private void Start()
    {
        gunPos = transform.position;
        originRotPoint = gunPivot.transform.localRotation;
        curAmmo = gunAmmo;
        
    }


    private void Update()
    {
        

        if (!PlayerGuns.playerGuns.fakeWeapon[0].activeSelf) 
        {
            tmp_curAmmo.text = "SMG : " + curAmmo;
        }
        if (!PlayerGuns.playerGuns.fakeWeapon[1].activeSelf) 
        {
            tmp_curAmmo.text = "Pistol : " + curAmmo;
        }
      
        
        
        if (!PlayerManager.playerManager.gameOver) 
        {
            gunShoot();
            gunSway();
            gunAiming();
            gunMovmenentAnim(); // sementara
        }
        if (PlayerManager.playerManager.test) 
        {
            
        }
        //gunRecoilUpdate();

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
            PlayerManager.playerManager.test = true;
           
        }
       
        
        if (Input.GetMouseButtonUp(0) || curAmmo==0)
        {
            gunAnim.SetBool("sht", false);
            isPlayershot = false;
            PlayerManager.playerManager.test = false;
        }
    }

    void rayCastHitShoot()
    {

        
        if (curAmmo > 0) 
        {
            curAmmo--;
        }
        else if (curAmmo <= 0) { curAmmo = 0; }
        AudioScript.instance.SMG_Sound();
        gunMuzzle.Play();
        gunRecoil();
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

    #region
    void gunRecoilUpdate() // bermasalah
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, Time.deltaTime * returnAmount);
        curRot = Vector3.Slerp(curRot, targetRot, Time.fixedDeltaTime * snappiness);

        cam.transform.localRotation = Quaternion.Euler(curRot); // bermaslah
        //Debug.Log(cam.transform.localRotation);
        back();
    }
    public void gunRecoil() 
    {
        targetPos -= new Vector3(0, 0, backToZ);
        if (!isAiming) 
        {
            targetRot += new Vector3(recoilX, 
                Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
            Debug.Log("not aim rec");
        }
        else 
        {
            targetRot += new Vector3(aimRecoilX,
                Random.Range(-aimRecoilY, aimRecoilY), Random.Range(-aimRecoilZ, aimRecoilZ));
            Debug.Log("aim rec");
        }
        
        //Debug.Log("recoil lah cok");
    }

    void back() 
    {
        targetPos = Vector3.Lerp(targetPos, gunPos, Time.deltaTime * returnAmount);
        curPos = Vector3.Lerp(curPos, targetPos, Time.fixedDeltaTime * snappiness);
        transform.localPosition = curPos;
    }
    #endregion

    void gunAiming() 
    {
        if (Input.GetMouseButton(1)) 
        {
            
            isAiming = true;    
        }
        else if (Input.GetMouseButtonUp(1) || PlayerManager.playerManager.gameOver)
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

    //--> bakal di tambah pas player jalan(tidak sprint)
    //--> pke animasi aja
    void gunMovmenentAnim()  
    {
        pos = gunPivot.transform.position;

        // idle pas diem
        if (!isPlayershot&&
            !isAiming&&
            !PlayerMovement.playerMovement.isSprint&&
             PlayerMovement.playerMovement.isInGround) 
        {
            gunPivot.transform.position = pos + new Vector3(0.0f,
                Mathf.Sin(curIdleSpeed * Time.time) * curIdlePower,
                0.0f);
        }
        if (!isPlayershot &&
           !isAiming
           && PlayerMovement.playerMovement.isSprint &&
            PlayerMovement.playerMovement.isInGround)
        {
            gunPivot.transform.position = pos + new Vector3(0.0f,
               Mathf.Sin(curSprintSpeed * Time.time) * curSprintPower,
               0.0f);
        }

    }
    private void OnEnable()
    {
        curAmmo = gunAmmo;
        
    }
    private void OnDisable()
    {
        
    }



}
