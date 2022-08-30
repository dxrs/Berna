using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController gunController;

    [Header("Gun Controller Required Variable atau Value")]
    public Camera cam;
    public Transform gunPivot;
    public Animator anim;

    [Header("Gun ID")]
    [SerializeField]
    [Tooltip("ID senjata nanti di panggil ke playerGun samakan nilai array yang di playerGun untuk swap weapon")]
    [Range(0, 4)]
    public int id;


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
    Quaternion originRotPoint;

    [Header("Gun Aiming")]
    [SerializeField] Vector3 defaultPos;
    [SerializeField] Vector3 aimingPos;
    [Tooltip("kecepatan pindah dari defaultPos ke aimPos dan sebaliknya")]
    [SerializeField] float movementAimPosSeed;
    [Tooltip("zoom pada saat aim pke fov dari camera")]
    [SerializeField] float aimFieldOfView;
    [Tooltip("default fov pas lagi tidak aim")]
    [SerializeField] float defaultFov;
    [SerializeField] bool isAiming;

    private void Awake()
    {
        gunController = this;
    }

    private void Start()
    {

    }


    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    public void gunShoot()
    {

    }

    void rayCastHitShoot()
    {

    }


}
