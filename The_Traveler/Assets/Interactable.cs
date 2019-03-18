using System.Collections;
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
    private Vector3 objectPos;
    private float distanceFromPlayer;

    private Rigidbody rb;
    private Transform t;
    public GameObject parent;
    
    void Start()
    {
        // get rigid body and transform
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        // check the distance between the player and the object
        distanceFromPlayer = Vector3.Distance(t.transform.position, parent.transform.position);

        // check if the player is withing grabbing distance
        if(distanceFromPlayer >= 20f)
            holdable = false;

        // if player is within holding distance and presses E then "grab" it
        if (holdable && Input.GetKey(KeyCode.E))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            t.SetParent(parent.transform);
        }
        else
        {
            // "let go" of the object
            objectPos = t.transform.position;
            t.SetParent(null);
            rb.useGravity = true;
            t.transform.position = objectPos;

        }
    }

    void OnMouseOver()
    {
        // if the player is within holding distance and is looking directly at the object
        if(distanceFromPlayer <= 20f)
        {
            holdable = true;
            rb.useGravity = false;
            rb.detectCollisions = true;
        }
    }

    // if the object gets out of the players center view let go
    void OnMouseExit()
    {
        holdable = false;
    }
}
