using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{

    ObjectPooler objectPooler;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Projectiles", transform.position, Quaternion.identity);
    }
    void Update() 
    {
    }
    void OnEnable()
    {
        //Shooting logic
    }
}
