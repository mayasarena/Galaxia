using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidBody;
    public bool isWalking;

    public float walkTime;
    public float waitTime;
    private float waitCounter;
    private float walkCounter;

    private int walkDirection;

    private Animator anim;

    [TextArea(5, 10)]
    public string dialogue;
    public GameObject chatButton;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private bool playerInBounds;

    void Start()
    {
        dialogueText.text = dialogue;
        chatButton.SetActive(false);
        dialogueBox.gameObject.SetActive(false);

        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            anim.SetBool("isMoving", true);

            // When done walking, wait
            if (walkCounter < 0)
            {
                waitCounter = waitTime;
                isWalking = false;
            }

            // Determine walk velocity and animation
            switch (walkDirection)
            {
            case 0:
                rigidBody.velocity = new Vector2(0, moveSpeed);
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", moveSpeed);
                break;
            case 1:
                rigidBody.velocity = new Vector2(moveSpeed, 0);
                anim.SetFloat("moveX", moveSpeed);
                anim.SetFloat("moveY", 0f);
                break;
            case 2:
                rigidBody.velocity = new Vector2(0, -moveSpeed);
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", -moveSpeed);
                break;
            case 3:
                rigidBody.velocity = new Vector2(-moveSpeed, 0);
                anim.SetFloat("moveX", -moveSpeed);
                anim.SetFloat("moveY", 0f);
                break;
            }
        }

        // Wait and choose a new direction if player is not in chatting bounds
        if (!isWalking && !playerInBounds)
        {
            waitCounter -= Time.deltaTime;
            anim.SetBool("isMoving", false);

            rigidBody.velocity = Vector2.zero;
            
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        walkCounter = walkTime;
        anim.SetBool("isMoving", true);
        isWalking = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            chatButton.SetActive(true);
            isWalking = false;
            playerInBounds = true;
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal") * -1);
            anim.SetFloat("moveY", Input.GetAxisRaw("Vertical") * -1);
            rigidBody.bodyType = RigidbodyType2D.Static; 

        }

        // Stop NPC from bumping into structures
        if (other.tag == "Environment")
        {
            waitCounter = waitTime;
            isWalking = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Disable chat UI when player exits chatting bounds
        if (other.tag == "Player")
        {
            playerInBounds = false;
            dialogueBox.gameObject.SetActive(false);
            chatButton.SetActive(false);
            rigidBody.bodyType = RigidbodyType2D.Dynamic; 
            isWalking = true;
        }
    }

    public void chat()
    {
        dialogueBox.gameObject.SetActive(true);
        chatButton.SetActive(false);
    }
    
}
