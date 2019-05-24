using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(playerPrefab) as GameObject;
        a.transform.position.Set(0,0,0);
    }
}
