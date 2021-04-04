using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 velocity;

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().HurtEnemy(5);
            Destroy(gameObject);
        }
    }
}
