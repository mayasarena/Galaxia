using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public GameObject particles;
    //public AudioSource hurtEnemyAudio;

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
    }

    public void HurtEnemy(int damage)
    {
        //hurtEnemyAudio.Play();
        currentHealth -= damage; // Decrease health
        if (currentHealth <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject); // Destroy enemy if killed
        }
    }

}