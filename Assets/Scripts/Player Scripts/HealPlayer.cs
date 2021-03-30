using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            FindObjectOfType<PlayerHealthManager>().HealPlayer(healAmount); // Heal the player
            Destroy(gameObject); // Destroy the healing item
        }
    }
}
