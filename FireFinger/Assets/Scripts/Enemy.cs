using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; //enemy HP
    public ParticleSystem deathEffect;
    private AnimationManager am;
    private ScoreManager sm;


    private void Start() 
    {
        am = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();
        sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    public void TakeDamage(int damage) //enemy collides with projectile
    {
        health -= damage;
        // FindObjectOfType<AudioManager>().Play("EnemyHit");
        if(health <= 0)
        {
            Die(); //enemy dies
            sm.scoreCount += 10;
        }        
    }

    void Die()
    {
        Instantiate (deathEffect, transform.position, Quaternion.identity); //death effect gets shown
        Destroy(gameObject); //enemy game object gets deleted
        FindObjectOfType<AudioManager>().Play("EnemyDeath"); //enemy death's sound effect
        am.Shake();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeHit(1);
            Die();
        }
    }
}
