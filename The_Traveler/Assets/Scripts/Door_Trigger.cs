using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    [SerializeField]
    GameObject door = null;
    // GameObject key = null;
    bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if(isOpen == false)
        {
            if(c.gameObject.gameObject.tag == "blue key")
            {
                isOpen = true;
                door.transform.position += new Vector3(0, -33, 0);
            }
        }
            
    }

    void OnTriggerExit(Collider c)
    {
        if(isOpen == true)
        {
            isOpen = false;
            door.transform.position += new Vector3(0, 33, 0);
        }
    }
}
