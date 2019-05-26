using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public ParticleSystem deathEffect;
    ObjectPooler objectPooler;


    // Start is called before the first frame update
    private void Start() 
    {
        objectPooler = ObjectPooler.Instance;        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        FindObjectOfType<AudioManager>().Play("ShootingProjectile");
        if(health <= 0)
        {
            Die();
        }        
    }

    // Update is called once per frame
    void Die()
    {
        Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
}
