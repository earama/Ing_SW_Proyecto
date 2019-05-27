using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Rigidbody2D rb;
    public float speed = 10f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    private void Start() 
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {  
        rb.velocity = transform.up * speed;
        if(transform.position.x >= screenBounds.x || transform.position.y >= screenBounds.y)
        {
            gameObject.SetActive(false);
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
}
