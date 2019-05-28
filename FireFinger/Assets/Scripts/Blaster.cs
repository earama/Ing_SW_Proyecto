using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{

    ObjectPooler objectPooler;
    private Vector2 screenBounds;
    public Vector3 previousPosition;
    private int frameCounter;
    public int numFramesTillShoot;
    public int speed;
    private bool firstUpdate;
    public Vector3 direccion;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        previousPosition = transform.position;
        frameCounter = 0;
        numFramesTillShoot = 2;
        speed = 3;
        direccion = Vector3.up;
    }

    void FixedUpdate()
    {
        if(previousPosition != transform.position){
            if(frameCounter >= numFramesTillShoot){
                objectPooler.SpawnFromPool("Projectiles", transform.position, Quaternion.identity);
                frameCounter = 0;
        }
        frameCounter++;
        } 
        previousPosition = transform.position;
    }
}
