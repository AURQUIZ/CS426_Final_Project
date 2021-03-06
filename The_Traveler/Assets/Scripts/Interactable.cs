﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    Noticable bugs....
    - changes to gravity boolean fight with each other causing the object to take it's time to fall.
    - if player turns too fast while holding an object, the object can't keep up and falls.
     */

public class Interactable : MonoBehaviour
{

    private bool holdable = false;
    private bool holdingObject = false;
    private Vector3 objectPos;
    private float distanceFromPlayer = 100f;
    private float time = 0.5f;

    private Rigidbody rb;
    private Transform t;
    private GameObject parent;
    
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Player");
        // get rigid body and transform
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(parent != null)
        {
            // check the distance between the player and the object
            distanceFromPlayer = Vector3.Distance(t.transform.position, parent.transform.position);

            // check if the player is withing grabbing distance
            if (distanceFromPlayer >= 20f)
                holdable = false;

            // if player is within holding distance and presses E then "grab" it
            if (holdable && Input.GetKey(KeyCode.E) && holdingObject == false && time < 0)
            {
                rb.useGravity = false;
                rb.detectCollisions = true;
                time = 0.5f;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                t.SetParent(parent.transform);
                holdingObject = true;
            }
            else if(Input.GetKey(KeyCode.E) && holdingObject == true && time < 0)
            {
                time = 0.5f;
                holdingObject = false;
                // "let go" of the object
                objectPos = t.transform.position;
                t.SetParent(null);
                rb.useGravity = true;
                t.transform.position = objectPos;

            }
        }
        
    }

    void OnMouseOver()
    {
        // if the player is within holding distance and is looking directly at the object
        if(distanceFromPlayer <= 20f && holdingObject == false)
        {
            holdable = true;
        }
    }

    // if the object gets out of the players center view let go
    void OnMouseExit()
    {
        holdable = false;
        holdingObject = false;
        objectPos = t.transform.position;
        t.SetParent(null);
        rb.useGravity = true;
        t.transform.position = objectPos;
    }
}
