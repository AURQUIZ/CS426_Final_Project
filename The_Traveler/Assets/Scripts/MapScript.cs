using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; //automatically attaches to player
    }
    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = target.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
