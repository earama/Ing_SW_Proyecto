using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;
    public Transform target;

    // Update is called once per frame
    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
    }
}
