using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    public GameObject key_object;

    public AudioSource doorOpen;
    public AudioSource doorClose;
    private Vector3 doorPositionY;
    private bool isLocked = true;

    void Start()
    {
        doorPositionY = door.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        // change the position of the door based on whether it is locked or not
        if (!isLocked)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 40);
        }
        else
        {
            door.transform.Translate(Vector3.down * Time.deltaTime * 40);
        }


        // make sure the door y position does not increase or decrease indefinitely
        if (door.transform.position.y > doorPositionY.y)
        {
            door.transform.position = doorPositionY;
        }
        if (door.transform.position.y < (doorPositionY.y - 50f))
        {
            door.transform.position = new Vector3(doorPositionY.x, doorPositionY.y - 50f, doorPositionY.z);
        }

    }

    void OnTriggerEnter(Collider c)
    {
        // if the correct collision occurs, set the lock bool to false 
        if (GameObject.ReferenceEquals(key_object, c.gameObject))
        {
            isLocked = false;
            doorOpen.Play();
        }
    }

    void OnTriggerExit(Collider c)
    {
        // set the lock bool to true because key is no longer set
        isLocked = true;
        doorClose.Play();
    }
}
