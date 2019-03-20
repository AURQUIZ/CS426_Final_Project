using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{


    [SerializeField]
    GameObject door;

    bool isOpen = false;

    public DoorTrigger()
    {
    }


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
                door.transform.position = new Vector3(0, -26, 0);

            }
        }

    }

    void OnTriggerExit(Collider c)
    {
        if(isOpen == false)
        {
            isOpen = true;
            door.transform.position = new Vector3(0, 26, 0);
                
        }

    }
    
}
