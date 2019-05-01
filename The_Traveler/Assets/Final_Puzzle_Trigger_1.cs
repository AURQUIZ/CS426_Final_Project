using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Puzzle_Trigger_1 : MonoBehaviour
{
    public GameObject key_1;
    public GameObject key_2;
    public GameObject key_3;

    public Final_Puzzle_Script mPuzzleScript;
    public AudioSource lockOpenSound;
    public AudioSource lockCloseSound;
    private Vector3 doorPositionY;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        // if the correct collision occurs, set the lock bool to false 
        if (GameObject.ReferenceEquals(key_1, c.gameObject) ||
            GameObject.ReferenceEquals(key_2, c.gameObject) ||
            GameObject.ReferenceEquals(key_3, c.gameObject))
        {
            if(mPuzzleScript.isKey1Placed == false)
            {
                mPuzzleScript.isKey1Placed = true;
            } else if (mPuzzleScript.isKey2Placed == false)
            {
                mPuzzleScript.isKey2Placed = true;
            } else if (mPuzzleScript.isKey3Placed == false)
            {
                mPuzzleScript.isKey3Placed = true;
            }
            
            lockOpenSound.Play();
        }
    }

    void OnTriggerExit(Collider c)
    {
        // set the lock bool to true because key is no longer set
        mPuzzleScript.isKey1Placed = false;
        lockCloseSound.Play();
    }
}
