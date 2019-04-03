using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravelManager : MonoBehaviour
{
    public GameObject player;
    public bool traveled = false;
    public float travelCooldown = 0f;
    private Vector3 offsetTravel = new Vector3(0, 0, 1000);

    // Update is called once per frame
    void Update()
    {
        travelCooldown -= Time.deltaTime;
        //Debug.Log(travelCooldown);

        if(Input.GetKeyDown(KeyCode.Q) && traveled == false && travelCooldown < 0)
        {
            Debug.Log("travled forward");
            Debug.Log(traveled);
            Debug.Log(travelCooldown);
            travelCooldown = 5f;
            player.transform.position += offsetTravel;
            traveled = true;

        } else if (Input.GetKeyDown(KeyCode.Q) && traveled == true && travelCooldown < 0)
        {
            Debug.Log("Traveled backward");
            Debug.Log(traveled);
            Debug.Log(travelCooldown);
            travelCooldown = 5f;
            player.transform.position -= offsetTravel;
            traveled = false;
        }

        
    }
}
