using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Puzzle_Script : MonoBehaviour
{


    [SerializeField]
    private GameObject door;

    public bool isKey1Placed = false;
    public bool isKey2Placed = false;
    public bool isKey3Placed = false;

    public AudioSource doorOpen;
    public AudioSource doorClose;
    private Vector3 doorPositionY;

    void Start()
    {
        doorPositionY = door.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        // change the position of the door based on whether it is locked or not
        if (isKey1Placed && isKey2Placed && isKey3Placed)
        {
            Debug.Log("keys are all placed!!");
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

}
