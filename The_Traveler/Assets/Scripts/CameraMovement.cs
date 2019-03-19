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
    // Start is called before the first frame update
    void Start()
    {
        leftBob = true; //player bobs to left first
        rightBob = false;
    }

    void WalkingAnimation()
    {
        if (controller.isGrounded == true)
        {
            if (isMoving == true)
            {
                if (leftBob == true)
                {
                    if (!anim.isPlaying)
                    {
                        anim.Play("walkLeft");
                        leftBob = false;
                        rightBob = true;
                    }
                }
                if (rightBob == true)
                {
                    if (!anim.isPlaying)
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
