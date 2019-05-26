using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    IEnumerator enemyWave()
    {
        do
        {
            yield return new WaitForSeconds(respawnTime);
            FindObjectOfType<AudioManager>().Play("EnemySpawn");
            spawnEnemy();
        }while(true);
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        // cual borde
        var ran = Random.Range(1,4);
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
        a.transform.position = new Vector2(posx, posy);
    }
}
