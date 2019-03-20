using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool isMoving;
    private bool leftBob;
    private bool rightBob;
    public Animation anim;
    public CharacterController controller;
    public AudioClip[] walkFloorClips;
    public AudioClip[] runFloorClips;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        leftBob = true; //player bobs to left first
        rightBob = false;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
    }

    void Step()
    {
        AudioClip clip = GetClip();
        if (!isMoving)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(clip, 0.5f); //plays clip
        }
    }

    private AudioClip GetClip()
    {
        bool isRunning = this.gameObject.GetComponentInChildren<Movement>().isRunning;
        if (isRunning)
        {
            return runFloorClips[UnityEngine.Random.Range(0, runFloorClips.Length)]; //gets random clip
        }
        else
        {
            return walkFloorClips[UnityEngine.Random.Range(0, walkFloorClips.Length)]; //gets random clip
        }
    }

    void WalkingAnimation()
    {
        if (controller.isGrounded == true) //if player is grounded
        {
            if (isMoving == true) //if player is moving
            {
                if (leftBob == true) //left side animation
                {
                    if (!anim.isPlaying) //if there's no anim playing
                    {
                        anim.Play("walkLeft");
                        leftBob = false; //wont do left bob next
                        rightBob = true; //does right bob next
                    }
                }
                if (rightBob == true) //right side animation
                {
                    if (!anim.isPlaying) //if there's no anim playing
                    {
                        anim.Play("walkRight");
                        rightBob = false; //wont do right bob next
                        leftBob = true; //does left bob next
                    }
                }
            }
            else
            {
                anim.Stop(); //stop animation immediately
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        // ANIMATING HEAD BOBS WHEN WALKING //
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX == 0 && inputY == 0)
            isMoving = false;
        else
            isMoving = true;

        WalkingAnimation();
    }
}
