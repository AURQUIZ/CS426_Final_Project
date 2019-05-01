using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed = 50;
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity = 10.0f;

    private float sensitivity = .3f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float maxPitch = 40;
    private float speedH = 6.0f;
    private float speedV = 6.0f;
    private Transform t;
    private CharacterController controller;
    private Vector3 movement;

    private bool isMoving;
    public bool canMove;
    public bool isRunning;
    public AudioSource jumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        t = GetComponent<Transform>();
        walkingSpeed = speed;
        runningSpeed = walkingSpeed * 1.5f;
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Time.timeScale = 1f;
            //Debug.Log("ABLE TO MOVE");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            // controls player movement
            //Debug.Log(controller.isGrounded);
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
                    movement += new Vector3(1, 0, 0);

                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                //Debug.Log(movement);
                // make sure it works no matter what direction player is at
                movement = transform.TransformDirection(movement);

                // Have the character jump
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    movement.y = 3;
                    jumpAudio.Play();
                }
            }

            // turn character based on mouse input
            pitch -= speedV * Input.GetAxis("Mouse Y") * sensitivity;
            yaw += speedH * Input.GetAxis("Mouse X") * sensitivity;

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
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
    }
}

