using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Rigidbody2D rb;
    public float speed = 2f;
    private Vector2 screenBounds;
    public GameObject player;
    public Vector3 position;
    public Vector3 prevPosition;
    private bool firstUpdate;
    private GameObject blaster;
    private bool firstEnable = true;

    private void Start() 
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = GameObject.FindWithTag("Player");
        blaster = GameObject.FindWithTag("Blaster");
        firstUpdate = true;
    }
    void Update()
    {  
        if(gameObject.activeSelf){
            if(firstUpdate){
            }
            if(transform.position.x >= screenBounds.x || transform.position.y >= screenBounds.y || transform.position.x <= -screenBounds.x || transform.position.y <= -screenBounds.y)
            {
                gameObject.SetActive(false);
            }
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
        if (!firstEnable) {
            rb.velocity = (prevPosition - position).normalized*speed;
        } else {
            firstEnable = false;
        }
    }
}
