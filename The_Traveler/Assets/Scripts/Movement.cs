﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 50;
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity = 10.0f;


    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float maxPitch = 40;
    private float speedH = 6.0f;
    private float speedV = 6.0f;
    private Transform t;
    public CharacterController controller;
    private Vector3 movement;

    private bool isMoving;
    public bool isRunning;
    private bool leftBob;
    private bool rightBob;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        t = GetComponent<Transform>();
        leftBob = true; //player bobs to left first
        rightBob = false;
        walkingSpeed = speed;
        runningSpeed = walkingSpeed * 1.5f;
    }

    void WalkingAnimation()
    {
        if(controller.isGrounded == true)
        {
            if (isMoving == true)
            {
                if(leftBob == true)
                {
                    if(!anim.isPlaying)
                    {
                        anim.Play("walkLeft");
                        leftBob = false;
                        rightBob = true;
                    }
                }
                if(rightBob == true)
                {
                    if(!anim.isPlaying)
                    {
                        anim.Play("walkRight");
                        rightBob = false;
                        leftBob = true;
                    }
                }
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // controls player movement
        if (controller.isGrounded)
        {
            // create a zero vector
            movement = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S)) //if player moves, but not backwards (cannot sprint while going back)
            {
                isRunning = true;
                speed = runningSpeed;
            }
            else
            {
                isRunning = false;
                speed = walkingSpeed;
            }

            // add values or subtract values based on key input
            // move character forward or backwards
            if (Input.GetKey(KeyCode.W))
                movement += new Vector3(0, 0, 1);
            else if (Input.GetKey(KeyCode.S))
                movement += new Vector3(0, 0, -1);

            // move character left or right
            if (Input.GetKey(KeyCode.A))
                movement += new Vector3(-1, 0, 0);
            else if (Input.GetKey(KeyCode.D))
                movement += new Vector3(1,0,0);

        

            // make sure it works no matter what direction player is at
            movement = transform.TransformDirection(movement);

            // Have the character jump
            if (Input.GetKeyDown(KeyCode.Space))
                movement.y = 4;

        }

        // turn character based on mouse input
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw += speedH * Input.GetAxis("Mouse X");

        // lock the pitch if the player looks too far down or up
        if (pitch >= maxPitch)
            pitch = maxPitch;
        else if (pitch <= -maxPitch)
            pitch = -maxPitch;

        // turn the player
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // apply gravity to the jump
        movement.y = movement.y - (gravity * Time.deltaTime);
        // move the player based on the key inputs
        controller.Move(movement * Time.deltaTime * speed);

        // ANIMATING HEAD BOBS WHEN WALKING //
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX == 0 || inputY == 0)
            isMoving = false;
        else
            isMoving = true;

        WalkingAnimation();

    }
}

