using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTravelManager : MonoBehaviour
{
    public Transform player;
    public CharacterController c;
    public bool traveled = false;
    public float travelCooldown = 0f;
    public Vector3 offsetTravel = new Vector3(0, 0, 1000);

    // Update is called once per frame
    void LateUpdate()
    {
        //travelCooldown -= Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.Q) && traveled == false && travelCooldown < 0)
        //{
        //    Debug.Log("travled forward");
        //    Debug.Log(traveled);
        //    Debug.Log(travelCooldown);

        //    travelCooldown = 5f;
        //    //c.Move(offsetTravel + transform.position);
        //    c.enabled = false;
        //    transform.position += offsetTravel;
        //    c.enabled = true;
        //    traveled = true;

        //}
        //else if (Input.GetKeyDown(KeyCode.Q) && traveled == true && travelCooldown < 0)
        //{

        //    Debug.Log("Traveled backward");
        //    Debug.Log(traveled);
        //    Debug.Log(travelCooldown);

        //    travelCooldown = 5f;
        //    c.enabled = false;
        //    transform.position -= offsetTravel;
        //    c.enabled = true;
        //    traveled = false;
        //}


    }

    public bool travelForward()
    {
        Debug.Log("travled forward");
        Debug.Log(traveled);
        Debug.Log(travelCooldown);

        travelCooldown = 5f;
        c.enabled = false;
        transform.position += offsetTravel;
        c.enabled = true;
        return true;
    }

    public bool travelBackward()
    {
        Debug.Log("Traveled backward");
        Debug.Log(traveled);
        Debug.Log(travelCooldown);

        travelCooldown = 5f;
        c.enabled = false;
        transform.position -= offsetTravel;
        c.enabled = true;
        return false;
    }
}
