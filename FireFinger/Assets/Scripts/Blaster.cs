using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    //scriptSet
    private ObjectPooler objectPooler;
    private Vector2 screenBounds;
    private Vector3 previousPosition;
    private int frameCounter = 0;

    //inspectorSet
    public int numFramesTillShoot;
    public int speed;
    public float minDistance;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        screenBounds = Camera.main.ScreenToWorldPoint //screen bounds (canvas)
        (
            new Vector3
            (
                Screen.width, Screen.height, Camera.main.transform.position.z
            )
        );
        previousPosition = transform.position; //initial position of the blaster
    }

    void Update()
    {
        if(!PauseMenu.gameIsPaused){ // if the game is running.
            var pos = transform.position; //blaster actual pos.
            var distance = Vector3.Distance(previousPosition, pos); //magnitud of vector (pos, previousPosition).
            if(previousPosition != pos && distance >= minDistance){ //if blaster is moving at least "x" distance.
                if(frameCounter >= numFramesTillShoot){ // if x frames have passed.
                    objectPooler.SpawnFromPool("Projectiles", pos, Quaternion.identity, previousPosition); //fire!
                    frameCounter = 0;
                }
                frameCounter++;
            }
            if(distance >= minDistance){  //if moving change previousposition.
                previousPosition = transform.position;
            }
        }
    }
}
