using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script va en el player
public class Player : MonoBehaviour
{
    public GameObject healthPrefab;
    public GameObject GameOverWindow;
    public int maxLives;
    public ParticleSystem collisionEffect;

    private List<GameObject> lives;
    private Vector2 screenBounds; // screen limits
    private ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        //set screen limits
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Set lives
        SetLives(maxLives);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLives(int maxNumLives) {
        lives = new List<GameObject>();
        for(int i = 0; i < maxNumLives; i++){
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

    public void TakeHit(int hits) //enemy collides with projectile
    {
        if (hits > lives.Count)
        {
            hits = lives.Count;
        }
        for(int i = 0; i < hits; i++){
            // Remove rightmost life
            Destroy(lives[lives.Count-1]);
            lives.RemoveAt(lives.Count-1);
            FindObjectOfType<AudioManager>().Play("PlayerCollision"); //player collision with enemy sound effect
            Instantiate(collisionEffect, transform.position, Quaternion.identity); //death effect gets shown
        }

        if (lives.Count == 0)
        {
            Die(); //player dies
        }        
    }

    public void Die()
    {
        sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        sm.UpdateHighScores();
       // Debug.Log("ABABA");
        
        GameOverWindow.SetActive(true); // Show Game Over
       // Debug.Log("FGFGFG");
        Time.timeScale = 0f; // Stop time
        Destroy(gameObject); // Player game object gets deleted
    }

    public int getNumLives()
    {
        return lives.Count;
    }
}
