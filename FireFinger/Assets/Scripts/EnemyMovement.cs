using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;

    // Update is called once per frame
    void Update() 
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, direction, speed* Time.deltaTime);
    }
}
