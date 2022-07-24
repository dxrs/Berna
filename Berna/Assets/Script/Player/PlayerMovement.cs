using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask groundMask;

    [SerializeField] float walkSpeed;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDist;
    [SerializeField] float jumpHeight;

    [SerializeField] Transform groundCheck;

    CharacterController characterController;

    bool isInGround;

    Vector3 velocity;
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
    }

 

    void pcMovement() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 playerMove= transform.right * x + transform.forward * y;

        characterController.Move(playerMove * walkSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
