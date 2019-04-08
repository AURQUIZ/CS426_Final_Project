using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelBar : MonoBehaviour
{

    public Slider travelBar;
    public Image travelFill;
    private float timeToTravel;

    // Start is called before the first frame update
    void Start()
    {
        timeToTravel = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        travelBar.value = Time.time / timeToTravel;
        travelFill.color = Color.Lerp(Color.gray, Color.cyan, travelBar.value);
    }
}
