using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// how enemy spawn
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 4.0f; // time to spawn
    private Vector2 screenBounds; // screen limits
    
    void Start()
    {
        //set screen limits
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // spawn enemy waves 
        StartCoroutine(enemyWave());
    }

    IEnumerator enemyWave()
    {
        do
        {
            yield return new WaitForSeconds(respawnTime); // wait for the time set to respawn new enemy
            FindObjectOfType<AudioManager>().Play("EnemySpawn"); // spawn sound
            spawnEnemy(); // call spwan method
        }while(true);
    }

    //spawn method
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject; // create enemy
        var ran = Random.Range(1,4); // cual borde
        float posx = 0;
        float posy = 0;
        if (ran == 1) { // Borde izquierdo
            posx = -screenBounds.x;
        } else if (ran == 2) { // Borde derecho
            posx = screenBounds.x;
        } else if (ran == 3) { // Borde arriba
            posy = screenBounds.y;
        } else { // Borde abajo
            posy = -screenBounds.y;
        }
        if (ran < 3) { // Borde izquierdo o derecho
            posy = Random.Range(-screenBounds.y, screenBounds.y);
        } else { // Borde arriba o abajo
            posx = Random.Range(-screenBounds.x, screenBounds.x);
        }
        a.transform.position = new Vector2(posx, posy); // spawn in posx, posy position
    }
}
