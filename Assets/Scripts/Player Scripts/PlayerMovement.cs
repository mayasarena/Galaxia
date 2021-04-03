using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 movement;
    private Animator anim;
    private bool isMoving;
    private float timer;
    public float energyLossRate = 1f;
    public VectorValueScriptableObject startingPos;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0f;
        transform.position = startingPos.value;
    }

    void Update()
    {
        // Get player movement
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        // Check if player is idle
        if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
        {
            isMoving = false;
        }
        // Check if player is moving, set animation
        else
        {
            // Lose energy as you move
            timer += Time.deltaTime;
            if (timer > energyLossRate)
            {
                timer = 0f;
                FindObjectOfType<PlayerStatsManager>().subtractEnergy(1);
            }
            isMoving = true;
            anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));

        }

        anim.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        // Make the player move
        Vector3 velocity = movement.normalized * moveSpeed;
        transform.position += velocity * Time.deltaTime;
        
    }
}
