using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageToGive = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            FindObjectOfType<PlayerHealthManager>().HurtPlayer(damageToGive); // Hurt player
        }
    }
}
