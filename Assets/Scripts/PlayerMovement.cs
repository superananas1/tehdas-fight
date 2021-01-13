﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public CharacterController controller;
    public float speed;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public float jumpHeight = 3.0f;
    public float crouchSpeed;
    public float crouchWalkSpeed;
    public bool isCrouching = false;
    public bool isCrouched = false;


    Vector3 velocity;
    bool isGrounded;
    
    // Update is called once per frame

    void Update()
    {
        Crouch();
        IsCrouchingVoid();
        //checks if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //if space is pressed, jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 

        }
        if (Input.GetKeyDown("left shift"))
        {
            speed = 15;
        }
        if (Input.GetKeyUp("left shift"))
        {
            speed = 5;
        }
        


            //gravity 
            velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isCrouched = !isCrouched;
            isCrouching = true;
        }
    }

    public void IsCrouchingVoid()
    {
        if (!isCrouched)
        {
            if (isCrouching)
            {
                Vector3 temp = transform.localScale;
                temp.y = 0.5f;
                temp.x = 0.5f;
                temp.z = 0.5f;
                transform.localScale = temp;

                if (temp.y <= 0.5f)
                {
                    temp.y = 0.5f;
                    isCrouching = false;
                }
            }
        }

        else if (isCrouched)
        {
            if (isCrouching)
            {
                Vector3 temp = transform.localScale;
                temp.y = 0.25f;
                temp.x = 0.25f;
                temp.z = 0.25f;
                transform.localScale = temp;

                
            }
        }
    }




}
