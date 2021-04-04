using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public PlayerData playerData;
    public int maxHealth = 100;
    public GameObject player;
    public HealthBar healthBar;
    public VectorValueScriptableObject respawnPositionVector;

    // Game Over stuff
    private float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    private float fadeTimer;
    public CanvasGroup deathUI;
    private bool playerIsDead = false;
    private float deathDelay = 1f;
    public GameObject healthParticles;
    public GameObject energyParticles;
    public Vector2 respawnPoint;
    private bool dyingFromEnergy = false;

    public Slider energySlider;
    private int maxEnergy;

    public bool invincible;
    public float invincibilityLength = 1.5f;
    private float invincibilityCounter = 0;
    
    void Start()
    {
        deathUI.alpha = 0;
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

        if (invincibilityCounter > 0) // decrement time
        {
            invincibilityCounter -= Time.deltaTime;
        }

        else // set invincibility as false if there's no time left
        {
            invincible = false;
        }
    }

    // Hurt the player
    public void HurtPlayer(int damage)
    {
        if (!invincible)
        {
            playerData.health -= damage; // Decrease health
            healthBar.SetHealth(playerData.health); // Set healthbar UI

            if (playerData.health > 0)
            {
                invincibilityCounter = invincibilityLength; // Start invincible counter
                invincible = true;
                StartCoroutine(Blink()); // blink player
            }
        }

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
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        if (dyingFromEnergy)
        {
            playerData.energy = (int) maxEnergy/2;
            energySlider.value = playerData.energy;
            dyingFromEnergy = false;
        }
        else{
            playerData.health = (int) maxHealth/2;
            healthBar.SetHealth(playerData.health);
        }
        respawnPositionVector.value = respawnPoint;
        FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
        FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
        SceneManager.LoadScene("HouseInterior");
    }

    public void energyDie()
    {
        dyingFromEnergy = true;
        StartCoroutine(DeathDelay());
    }

    private IEnumerator Blink()
    {
        while (invincible)
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
 }
