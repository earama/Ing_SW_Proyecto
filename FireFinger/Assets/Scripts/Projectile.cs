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
    public Vector3 position;
    public Vector3 prevPosition;
    private bool firstUpdate;
    private GameObject blaster;

    // Start is called before the first frame update
    private void Start() 
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = GameObject.FindWithTag("Player");
        blaster = GameObject.FindWithTag("Blaster");
        //position = player.transform.position;
        prevPosition = blaster.GetComponent<Blaster>().previousPosition;
        firstUpdate = true;
    }
    void Update()
    {  
        if(gameObject.activeSelf){
            //rb.velocity = transform.up * speed;
            if(firstUpdate){
                
                //position = player.transform.position;
                //prevPosition = blaster.GetComponent<Blaster>().previousPosition;
                firstUpdate = false;
                //Debug.Log("projectile FIRST UPDATE");
                //Debug.Log("projectile prevPos");
               // Debug.Log(prevPosition);
                //Debug.Log("projectile Pos");
               // Debug.Log(position);
            }
            /* if(position = prevPosition){
                firstUpdate = true;
                //rb.velocity = transform.up * speed;
            }*/
            Debug.Log("projectile prevPos");
            Debug.Log(prevPosition);
            Debug.Log("projectile Pos");
            Debug.Log(position);

            //rb.velocity = Vector2.MoveTowards(position, prevPosition, 1).normalized*-speed;
            rb.velocity = (prevPosition - position).normalized*-speed;
            /*
            if(prevPosition != position){
                rb.velocity = (prevPosition - position).normalized*-speed;
            } else {
                gameObject.SetActive(false);
            }*/
            
            
            //rb.velocity = Vector3.MoveTowards(position, prevPosition, speed*Time.deltaTime);
            if(transform.position.x >= screenBounds.x || transform.position.y >= screenBounds.y || transform.position.x <= -screenBounds.x || transform.position.y <= -screenBounds.y)
            {
                gameObject.SetActive(false);
            }
            //prevPosition = position;
        }
        
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


    void OnEnable()
    {
        firstUpdate = true;
    }
}
