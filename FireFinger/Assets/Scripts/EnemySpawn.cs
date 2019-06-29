using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// how enemy spawn
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime; // time to spawn in seconds
    private Vector2 screenBounds; // screen limits
    private float speedModifier;
    private float respawnTimeModifier;
    
    void Start()
    {
        // initialize variables
        speedModifier = 1;
        respawnTimeModifier = 1;
        // get screen limits
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // spawn enemy waves 
        StartCoroutine(enemyWave());
    }

    IEnumerator enemyWave()
    {
        do
        {
            yield return new WaitForSeconds(respawnTime*respawnTimeModifier); // wait for the time set to respawn new enemy
            FindObjectOfType<AudioManager>().Play("EnemySpawn"); // spawn sound
            spawnEnemy(); // call spwan method
        }while(true);
    }

    //spawn method
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject; // create enemy
        // set speed
        a.GetComponent<EnemyMovement>().ModifySpeed(speedModifier);
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

    public void SetSpeedModifier(float newValue)
    {
        speedModifier = newValue;
    }

    public void SetRespawnTimeModifier(float newValue)
    {
        respawnTimeModifier = newValue;
    }

    public void MultiplySpeedModifier(float multiplier)
    {
        speedModifier *= multiplier;
    }

    public void MultiplyRespawnTimeModifier(float multiplier)
    {
        respawnTimeModifier *= multiplier;
    }
}
