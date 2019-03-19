using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapScript : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = target.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, 0f);
    }
}
