using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    private float timeToRest = 0f;
    private bool fullLoop;
    private float soundRadius = 35f;
    private bool hasGoneOffPatrol;
    public Transform checkpoint_01;
    public Transform checkpoint_02;
    public Transform checkpoint_03;
    public Transform player;
    public Animator animator;
    
    
    void Start()
    {
        agent.SetDestination(checkpoint_01.position);
        fullLoop = false;
        hasGoneOffPatrol = false;
        //animator = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        //Debug.Log(distanceFromPlayer);

        // depending on where the unit is, move to specified location
        if (distanceFromPlayer <= soundRadius)
        {
            agent.SetDestination(player.position);
            animator.SetInteger("Walking", 0);
            hasGoneOffPatrol = true;
            soundRadius = 150f;
            agent.speed = 40f;
        } else if(transform.position.z == checkpoint_01.position.z && transform.position.x == checkpoint_01.position.x)
        {

            // once resting is done, start walking to checkpoint 2
            //if (timeToRest < 0)
            //{
            //Debug.Log("Setting second Checkpoint!");
            agent.SetDestination(checkpoint_02.position);
            animator.SetInteger("Walking", 0);
                //timeToRest = 5f;
            //}
           // else
            //{
                // give the unit time to rest
                //timeToRest -= Time.deltaTime;
                //animator.SetInteger("Walking", 1);
            //}
                

        }else if(transform.position.z == checkpoint_02.position.z && transform.position.x == checkpoint_02.position.x)
        {


            if (timeToRest < 0)
            {
            //Debug.Log(fullLoop);
                // once resting is done, start walking to checkpoint 1 or 3 depending on whether a full loop was done
                if (fullLoop)
                {
                    agent.SetDestination(checkpoint_01.position);
                    animator.SetInteger("Walking", 0);
                    fullLoop = false;
                }
                else
                {
                    agent.SetDestination(checkpoint_03.position);
                    animator.SetInteger("Walking", 0);
                    fullLoop = true;
                }
                
                timeToRest = 1f;
            }
            else
            {
                // give the unit time to rest
                timeToRest -= Time.deltaTime;
                //animator.SetInteger("Walking", 1);
            }
            
        } else if(transform.position.z == checkpoint_03.position.z && transform.position.x == checkpoint_03.position.x)
        {

            // once resting is done, start walking to checkpoint 2
            //if (timeToRest < 0)
            //{
                agent.SetDestination(checkpoint_02.position);
                animator.SetInteger("Walking", 0);
                //timeToRest = 5f;
            //}
           // else
            //{
                // give the unit time to rest
                //timeToRest -= Time.deltaTime;
                //animator.SetInteger("Walking", 1);
            //}
        } else
        {
            //Debug.Log("Else statement Entered!!");
            if(hasGoneOffPatrol)
            {
                agent.SetDestination(checkpoint_01.position);
                animator.SetInteger("Walking", 0);
                hasGoneOffPatrol = false;
                soundRadius = 35f;
                agent.speed = 10f;
            }
            //agent.SetDestination(checkpoint_01.position);
        }
    }
}
