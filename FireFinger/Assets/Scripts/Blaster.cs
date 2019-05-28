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
    public float minDistance = 0.0f;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Distance");
        //Debug.Log(Vector3.Distance(previousPosition, transform.position));
        //Debug.Log("prevPos");
        //Debug.Log(previousPosition);
        //Debug.Log("Pos");
        //Debug.Log(transform.position);
        var distance = Vector3.Distance(previousPosition, transform.position);
        if(previousPosition != transform.position && distance >= minDistance){

            if(frameCounter >= numFramesTillShoot){
                objectPooler.SpawnFromPool("Projectiles", transform.position, Quaternion.identity, previousPosition);
                frameCounter = 0;
            }
            frameCounter++;

        }
        if(distance >= minDistance){
            previousPosition = transform.position;
        }
            
        


    }
    void FixedUpdate() 
    {

    }
    void OnEnable()
    {
        //Shooting logic
    }
}
