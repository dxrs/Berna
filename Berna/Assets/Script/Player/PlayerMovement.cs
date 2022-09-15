using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement playerMovement;

    public LayerMask groundMask;

    public bool isMoving;
    public bool isSprint;
    public bool isPlayerWalk;
    public bool isInGround;
    public bool isRegenerated;

    [SerializeField] float walkSpeed;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDist;
    [SerializeField] float jumpHeight;
   

    [SerializeField] Transform groundCheck;

    CharacterController characterController;

    

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

        if (!PlayerManager.playerManager.gameOver) 
        {
            jumpInput();
            movementInput();
            movementSpeed();
        }
      
    }


    void jumpInput() 
    {
        isInGround = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isInGround && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isInGround)
        {
            if (InGameUI.inGameUI.playerStamina > 0.0f)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            }

        }

       
    }
    void movementInput() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 playerMove= transform.right * x + transform.forward * y;

        characterController.Move(playerMove * walkSpeed * Time.deltaTime);
        //Debug.Log( walkSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (!isInGround || isSprint)
        {
            if (InGameUI.inGameUI.playerStamina > 0.0f)
            {
                InGameUI.inGameUI.playerStamina -= 10 * Time.deltaTime;
            }
        }
        if (InGameUI.inGameUI.playerStamina < 0f)
        {
            isRegenerated = true;
        }
        //-> player sprint 
        #region
        if (Input.GetKey(KeyCode.W) ||
               Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) ||
               Input.GetKey(KeyCode.D))
        {
            isPlayerWalk = true;
            if (Input.GetKey(KeyCode.LeftShift) && isInGround)
            {
                isSprint = true;
                if (InGameUI.inGameUI.playerStamina > 0.0f) 
                {
                    //InGameUI.inGameUI.playerStamina -= 10 * Time.deltaTime;
                }
            }
           
        }
        if (Input.GetKeyUp(KeyCode.W) ||
              Input.GetKeyUp(KeyCode.A) ||
              Input.GetKeyUp(KeyCode.S) ||
              Input.GetKeyUp(KeyCode.D))
        {
            isPlayerWalk = false;
            if (Input.GetKey(KeyCode.LeftShift) && !isPlayerWalk)
            {
                isSprint = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprint = false;
        }
        if (!isSprint) 
        {
            if (InGameUI.inGameUI.playerStamina < 100.0f && !isRegenerated &&isInGround)
            {
                InGameUI.inGameUI.playerStamina += 12 * Time.deltaTime;
            }
            if (isRegenerated) 
            {
                StartCoroutine(playerMoveRegenerated());
            }
        }
        #endregion 


    }

    void movementSpeed() 
    {

        //utk movement aiming msh atomatis pelan
        // pgnnya di buat sperti valorant
        if (GunController.gunController != null) 
        {
            if (GunController.gunController.isAiming && !isSprint)
            {
                walkSpeed = 3;
            }
            else if (!GunController.gunController.isAiming && isSprint)
            {
                if (InGameUI.inGameUI.playerStamina > 0.0f) 
                {
                    walkSpeed = 8.2f;
                }
                else 
                {
                    walkSpeed = 4;
                }
                
            }

            else if (GunController.gunController.isAiming && isSprint)
            {
                walkSpeed = 3;
            }
            else if (!GunController.gunController.isAiming && !isSprint)
            {
                walkSpeed = 6;
            }
        }
       
       
       


    }

    IEnumerator playerMoveRegenerated() 
    {
        yield return new WaitForSeconds(5);
        if (isRegenerated) 
        {
            
            isRegenerated = false;
            
            InGameUI.inGameUI.playerStamina += 12 * Time.deltaTime;
        }
    }
}
