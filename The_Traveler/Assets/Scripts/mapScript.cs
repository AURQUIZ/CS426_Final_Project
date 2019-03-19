using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapScript : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;
        transform.position = targetPosition;
    }
}
