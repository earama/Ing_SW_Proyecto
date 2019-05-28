using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; //enemy HP
    public ParticleSystem deathEffect;
    ObjectPooler objectPooler;


    private void Start() 
    {
        objectPooler = ObjectPooler.Instance;        
    }
    public void TakeDamage(int damage) //enemy collides with projectile
    {
        health -= damage;
        // FindObjectOfType<AudioManager>().Play("EnemyHit");
        if(health <= 0)
        {
            Die(); //enemy dies
        }        
    }

    void Die()
    {
        Instantiate (deathEffect, transform.position, Quaternion.identity); //death effect gets shown
        Destroy(gameObject); //enemy game object gets deleted
        FindObjectOfType<AudioManager>().Play("EnemyDeath"); //enemy death's sound effect
    }
}
