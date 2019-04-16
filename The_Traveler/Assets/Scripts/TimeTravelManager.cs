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
    public AudioSource bad_music;
    public AudioSource good_music;
    public AudioSource time_travel_sound;
    public GameObject sunSource;

    public bool travelForward()
    {
        Debug.Log("travled forward");
        Debug.Log(traveled);
        Debug.Log(travelCooldown);

        sunSource.SetActive(true);
        time_travel_sound.Play();
        bad_music.Stop();
        good_music.Play();

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

        sunSource.SetActive(false);

        time_travel_sound.Play();
        bad_music.Play();
        good_music.Stop();
        travelCooldown = 5f;
        c.enabled = false;
        transform.position -= offsetTravel;
        c.enabled = true;
        return false;
    }

    public void Awake()
    {
        bad_music.Play();
        sunSource.SetActive(false);
    }
}
