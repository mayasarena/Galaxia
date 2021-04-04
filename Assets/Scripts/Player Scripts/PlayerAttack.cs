using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed;
    private Vector2 target;
    private float step;
    private GameObject projectile;
    private bool projected;
    private float disableTime = 1f;
    private float disableCounter = 0;
    private bool disabled;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !disabled)
        {
            Shoot();
            disabled = true;
            disableCounter = disableTime;

        }

        if (disableCounter > 0) // decrement time
        {
            disableCounter -= Time.deltaTime;
        }

        else // set disabled to false
        {
            disabled = false;
        }
    }

    public void Shoot()
    {
        Vector3 worldPoint = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(worldPoint);
        Vector2 direction = mousePos - (Vector2) transform.position;
        direction.Normalize();
        direction *= speed;
        projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().velocity = direction;
    }
}
