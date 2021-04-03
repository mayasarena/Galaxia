using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public PlayerData playerData;
    public int maxHealth = 100;
    public GameObject player;
    public HealthBar healthBar;

    // Game Over stuff
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    private float fadeTimer;
    public CanvasGroup deathUI;
    private bool playerIsDead = false;
    public float deathDelay = 1f;
    public GameObject healthParticles;
    public GameObject energyParticles;
    public Transform respawnPoint;
    private bool dyingFromEnergy = false;

    public Slider energySlider;
    private int maxEnergy;

    // Audio Stuff
    /*
    public AudioSource hitPlayerAudio;
    public AudioSource deathAudio;
    public AudioSource healAudio;
    */
    
    void Start()
    {
        maxEnergy = FindObjectOfType<PlayerStatsManager>().maxEnergy;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(playerData.health);
    }

    void Update()
    {
        if (playerIsDead)
        {
            Die(); // :(
        }
    }

    // Hurt the player
    public void HurtPlayer(int damage)
    {
        //hitPlayerAudio.Play();

        playerData.health -= damage; // Decrease health
        healthBar.SetHealth(playerData.health); // Set healthbar UI

        if (playerData.health <= 0) // Kill player
        {
            //deathAudio.Play();
            StartCoroutine(DeathDelay());
        }
    }

    // Heal the player
    public void HealPlayer(int heal)
    {
        //healAudio.Play();
        
        if ((playerData.health + heal) >= maxHealth) // If health goes above max health, the health is equal to max health
        {
            playerData.health = maxHealth;
            healthBar.SetHealth(playerData.health); // Set healthbar UI
        }

        else 
        {
            playerData.health += heal; // Increase health
            healthBar.SetHealth(playerData.health); // Set healthbar UI
        } 
    }

    public void Die()
    {
         // Fade to the game over screen
        fadeTimer += Time.deltaTime;
        deathUI.alpha = fadeTimer / fadeDuration;

        if(fadeTimer > fadeDuration + displayImageDuration)
        {
            Respawn();
        }
    }

    // Delay the fade for a couple of seconds
    private IEnumerator DeathDelay()
    {
        if (dyingFromEnergy)
        {
            Instantiate(energyParticles, player.transform.position, player.transform.rotation);
        }
        else{
            Instantiate(healthParticles, player.transform.position, player.transform.rotation);
        }
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(deathDelay);
        playerIsDead = true;
    }

    private void Respawn()
    {
        playerIsDead = false;
        dyingFromEnergy = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        if (dyingFromEnergy)
        {
            playerData.energy = (int) maxEnergy/2;
            energySlider.value = playerData.energy;
        }
        else{
            playerData.health = (int) maxHealth/2;
            healthBar.SetHealth(playerData.health);
        }
        player.transform.position = respawnPoint.position;
        deathUI.alpha = 0;
    }

    public void energyDie()
    {
        dyingFromEnergy = true;
        StartCoroutine(DeathDelay());
    }
    
 }
