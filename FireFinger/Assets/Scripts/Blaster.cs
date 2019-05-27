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

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        previousPosition = transform.position;
        frameCounter = 0;
        numFramesTillShoot = 3;
        speed = 3;
        direccion = Vector3.up;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(previousPosition != transform.position){
            //direccion = Vector3.up;
            //firstUpdate = true;
            if(frameCounter >= numFramesTillShoot){
                objectPooler.SpawnFromPool("Projectiles", transform.position, Quaternion.identity, previousPosition, speed);

                
                
                frameCounter = 0;
        }
        frameCounter++;

        } else {
            //direccion = previousPosition;
            //firstUpdate = false;
        }
        
        previousPosition = transform.position;
        //transform.rotation = Quaternion.LookRotation (previousPosition);
        //objectPooler.SpawnFromPool("Projectiles", transform.position, Quaternion.identity);
        


    }
    void Update() 
    {
    }
    void OnEnable()
    {
        //Shooting logic
    }
}
