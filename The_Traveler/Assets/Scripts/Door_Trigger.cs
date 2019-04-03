using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    GameObject key;

    public AudioSource doorOpen;
    public AudioSource doorClose;
    bool isOpen = false;
    bool isOpening;
    bool isClosing;
    float doorPositionY;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isOpening == true)
        {
            door.transform.Translate(Vector3.down * Time.deltaTime * 40);
        }
        if(door.transform.position.y < doorPositionY - 50f)
        {
            isOpening = false;
        }

        if(isClosing == true)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 40);
        }
        if (door.transform.position.y > doorPositionY + 50f)
        {
            isClosing = false;
        }
        
    }

    void OnTriggerEnter(Collider c)
    {
        if(isOpen == false)
        {
            if(c.gameObject.gameObject.tag == "blue key")
            {
                isOpen = true;
                isOpening = true;
                doorPositionY = door.transform.position.y;
                doorOpen.Play();
            }
        }
            
    }

    void OnTriggerExit(Collider c)
    {
        if(isOpen == true)
        {
            isOpen = false;
            isClosing = true;
            doorPositionY = door.transform.position.y;
            doorClose.Play();
        }
    }
}
