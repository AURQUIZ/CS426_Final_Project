using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering_Lights : MonoBehaviour
{
    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flashing()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
        }
    }
}
