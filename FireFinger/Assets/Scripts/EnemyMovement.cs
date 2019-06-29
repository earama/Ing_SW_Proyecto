using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to define enemy movement
public class EnemyMovement : MonoBehaviour
{
    public float speed;

    void Update() 
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get position of touch
        transform.position = Vector2.MoveTowards(transform.position, direction, speed* Time.deltaTime); // move towards the touch
    }

    public void ModifySpeed(float multiplier)
    {
        speed = speed * multiplier;
    }
}
