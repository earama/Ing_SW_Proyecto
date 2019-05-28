using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Rigidbody2D rb;
    public float speed = 10f;
    private Vector2 screenBounds;
    public GameObject player;
    private Vector3 position;
    private Vector3 prevPosition;
    private bool firstUpdate;
    private GameObject blaster;

    // Start is called before the first frame update
    private void Start() 
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = GameObject.FindWithTag("Player");
        blaster = GameObject.FindWithTag("Blaster");
        position = player.transform.position;
        prevPosition = blaster.GetComponent<Blaster>().previousPosition;
        firstUpdate = true;
    }
    void Update()
    {  
        
        //rb.velocity = transform.up * speed;
        if(firstUpdate){
            position = player.transform.position;
            prevPosition = blaster.GetComponent<Blaster>().previousPosition;
            firstUpdate = false;
        }
        /* if(position = prevPosition){
            firstUpdate = true;
            //rb.velocity = transform.up * speed;
        }*/
        
        rb.velocity = Vector3.MoveTowards(position, prevPosition, 1).normalized*-10;
        //rb.velocity = Vector3.MoveTowards(position, prevPosition, speed*Time.deltaTime);
        if(transform.position.x >= screenBounds.x || transform.position.y >= screenBounds.y)
        {
            gameObject.SetActive(false);
        }
        //prevPosition = position;
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            
           
            enemy.TakeDamage(damage);
            gameObject.SetActive(false);
        }
        
     
    }

    void OnDisable()
    {
        firstUpdate = true;
    }
}
