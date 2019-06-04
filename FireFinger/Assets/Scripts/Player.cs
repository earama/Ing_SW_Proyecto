using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script va en el player
public class Player : MonoBehaviour
{
    public GameObject healthPrefab;
    public int maxLives;

    private List<GameObject> lives;
    private Vector2 screenBounds; // screen limits
    // Start is called before the first frame update
    void Start()
    {
        //set screen limits
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Set lives
        lives = new List<GameObject>();
        for(int i = 0; i < maxLives; i++){
            GameObject curLife = Instantiate(healthPrefab) as GameObject;
            // Get dimensions
            var heartWidth = curLife.GetComponent<SpriteRenderer>().bounds.size.x;
            var heartHeight = curLife.GetComponent<SpriteRenderer>().bounds.size.y;
            // Give position
            Vector2 pos = new Vector2(-screenBounds.x + heartWidth/2*(i+1), screenBounds.y-heartHeight/2); 
            curLife.transform.position = new Vector2(-screenBounds.x + heartWidth*(i+1), screenBounds.y-heartHeight);
            // Add to list
            lives.Add(curLife);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(int hits) //enemy collides with projectile
    {
        for(int i = 0; i < hits; i++){
            // Remove rightmost life
            Destroy(lives[lives.Count-1]);
            lives.RemoveAt(lives.Count-1);
            FindObjectOfType<AudioManager>().Play("PlayerCollision"); //player collision with enemy sound effect
        }

        if (lives.Count == 0)
        {
            Die(); //player dies
            SceneManager.LoadScene("FingerFire");
        }        
    }

    public void Die()
    {
        Destroy(gameObject); //player game object gets deleted
    }
}
