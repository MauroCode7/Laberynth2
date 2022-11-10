using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{


    public float speed = 12f;
    public float gravity = -9.81f;
    public CharacterController controller;
    Vector3 velocity; 
    public Transform groundCheck;
    public static Vector3 playerPos;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3f;

    public bool isSprinting;

    public float sprintingSpeedMultiplier = 1.5f;

    private float sprintSpeed = 1f;
    internal static object instance;

    void Start()
    {
        StartCoroutine(TrackPlayer());
    }
    
    IEnumerator TrackPlayer ()
    {
        while (true)
        {
                playerPos = gameObject.transform.position;
                yield return null;
        }
            
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        
        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical"); 


        Vector3 move = transform.right * x + transform.forward * z;

        JumpCheck();
        
        RunCheck();
        
        controller.Move(move * speed * Time.deltaTime*sprintSpeed);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); 

    }

    void JumpCheck()
    {
          if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;
        }   
    
        if(isSprinting == true)
        {
            sprintSpeed = sprintingSpeedMultiplier;
        }else{
            sprintSpeed = 1;
        }


    }
}

