using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Test");
        gameObject.layer = 10;
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Test2");
        gameObject.layer = 11;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
        gameObject.layer = 10;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Test");
        gameObject.layer = 11;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Test");
        gameObject.layer = 10;
    }
}
