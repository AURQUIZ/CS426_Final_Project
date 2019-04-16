using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelBar : MonoBehaviour
{

    public Slider travelBar;
    public Image travelFill;
    private float timeToTravel = 5f;
    public bool traveled = false;
    public TimeTravelManager manager;
    public float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        // add to the cooldown
        cooldown += Time.deltaTime;

        // calculate to let player know through UI
        travelBar.value = cooldown / timeToTravel;
        travelFill.color = Color.Lerp(Color.gray, Color.cyan, travelBar.value);

        // once the ability is up the player can travel
        if(travelBar.value == 1) //maxed out
        {
            // travel depending on what timeline
            if (Input.GetKeyDown(KeyCode.Q) && traveled == false)
            {
                traveled = manager.travelForward();

                // reset cooldown bar
                cooldown = 0;
                travelBar.value = cooldown / timeToTravel;
                travelFill.color = Color.Lerp(Color.gray, Color.cyan, travelBar.value);
            }
            else if (Input.GetKeyDown(KeyCode.Q) && traveled == true)
            {
                traveled = manager.travelBackward();

                // reset cooldown bar
                cooldown = 0;
                travelBar.value = cooldown / timeToTravel;
                travelFill.color = Color.Lerp(Color.gray, Color.cyan, travelBar.value);
            }

        }
        /* IF PLAYER USES TIME TRAVEL 
         * RESET TRAVEL BAR TO 0
         * travelBar.value = 0f; */
    }

    void updateTravelTime(float time) //Perks that can maybe lower the cooldown to travel?
    {
        timeToTravel = time;
    }
}
