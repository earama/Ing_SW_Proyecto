﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enemy sprite movement
public class LookAt : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // position to aim at
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // angle to rotate to
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime); // movement
    }
}
