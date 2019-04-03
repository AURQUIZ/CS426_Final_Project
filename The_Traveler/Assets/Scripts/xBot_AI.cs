using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xBot_AI : MonoBehaviour
{
    public Transform Player;
    public float alertDistance;
    public float speed;

    private Animator anim;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //walking
        if(anim.GetBool("isIdle") == true)
        {

            direction = Player.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.9f * Time.deltaTime);
            transform.Translate(0, 0, speed);

            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }



        //when it sees the character, stop
        else if(Vector3.Distance(Player.position,transform.position) < alertDistance)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }
    }
}
