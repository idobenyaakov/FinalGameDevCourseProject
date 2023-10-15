using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Boolean isGrounded;
    private Boolean lerpCrouch;
    private Boolean crouching;
    private Boolean sprinting;
    private Boolean slide;
    private Boolean timer;
    private float timerDuration;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    public float crouchTimer = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        slide = false;
        timerDuration = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1; ;
            p *= p;
            if(crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if(p >1) 
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }
        if (timer)
        {
            timerDuration -= Time.deltaTime;
            if (timerDuration <= 0)
            {
                speed = 9;
                sprinting = true;
                crouching = false;
                slide = false;
                timer = false;
                timerDuration = 1f;
            }
        }
    }
    //InputManager.cs -> character controller 
    public void ProcessMove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection)* speed *Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) 
        { 
            playerVelocity.y = -2f;

            if(slide)
            {
                speed = 15;
                timer = true;
            }

        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (isGrounded) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void Crouch()
    {
        if (!slide)
        {
            if (isGrounded)
            {
                crouching = !crouching;
                crouchTimer = 0f;
                lerpCrouch = true;
                if (crouching)
                {
                    speed = 4;
                    sprinting = false;
                }
                else
                    speed = 6;
            }
            else if (!isGrounded && sprinting)
            {
                slide = true;
                crouching = true;
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
        
    }
    public void Sprint()
    {
        if (!slide)
        {
            if (isGrounded)
            {
                if (crouching)
                {
                    // If crouching, first stand up
                    crouching = false;
                    lerpCrouch = true;
                    crouchTimer = 0f;
                    speed = 6; // Set the speed back to the normal value
                }
                sprinting = !sprinting;
                if (sprinting)
                    speed = 9;
                else
                    speed = 6;
            }
        }
    }
}
