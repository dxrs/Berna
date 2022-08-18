using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement playerMovement;

    public LayerMask groundMask;

    public bool isMoving;
    public bool isSprint;
    public bool isPlayerIdle;

    [SerializeField] float walkSpeed;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDist;
    [SerializeField] float jumpHeight;
   

    [SerializeField] Transform groundCheck;

    CharacterController characterController;

    bool isInGround;

    Vector3 velocity;
    private void Awake()
    {
        playerMovement = this;
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {
    
        isInGround = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if(isInGround && velocity.y < 0f) 
        {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isInGround) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        pcMovement();
        movementSpeed();
    }

 

    void pcMovement() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 playerMove= transform.right * x + transform.forward * y;

        characterController.Move(playerMove * walkSpeed * Time.deltaTime);
        //Debug.Log( walkSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        

        //-> player sprint 
        #region
        if (Input.GetKey(KeyCode.W) ||
               Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) ||
               Input.GetKey(KeyCode.D))
        {
            isPlayerIdle = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprint = true;
            }
           
        }
        if (Input.GetKeyUp(KeyCode.W) ||
              Input.GetKeyUp(KeyCode.A) ||
              Input.GetKeyUp(KeyCode.S) ||
              Input.GetKeyUp(KeyCode.D))
        {
            isPlayerIdle = false;
            if (Input.GetKey(KeyCode.LeftShift) && !isPlayerIdle)
            {
                isSprint = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprint = false;
        }
        #endregion 


    }

    void movementSpeed() 
    {

        //utk movement aiming msh atomatis pelan
        // pgnnya di buat sperti valorant

        if (GunAiming.gunAiming.isAiming && !isSprint) 
        {
            walkSpeed = 3;
        }
        else if (!GunAiming.gunAiming.isAiming && isSprint)
        {
            walkSpeed=8.2f;
        }

        else if(GunAiming.gunAiming.isAiming && isSprint)
        {
            walkSpeed = 3;
        }
        else if(!GunAiming.gunAiming.isAiming && !isSprint) 
        {
            walkSpeed = 6;
        }
       
       


    } 
}
