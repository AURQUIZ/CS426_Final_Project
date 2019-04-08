using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelBar : MonoBehaviour
{

    public Slider travelBar;
    public Image travelFill;
    private float timeToTravel = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        travelBar.value = Time.time / timeToTravel;
        travelFill.color = Color.Lerp(Color.gray, Color.cyan, travelBar.value);
        if(travelBar.value == 1) //maxed out
        {
            Debug.Log("TIME TRAVEL READY");
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
