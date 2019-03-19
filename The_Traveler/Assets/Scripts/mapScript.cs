﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = target.position.y + 100;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
