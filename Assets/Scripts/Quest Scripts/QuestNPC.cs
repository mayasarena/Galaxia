using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestNPC : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidBody;
    public bool isWalking;

    public QuestScriptableObject quest;

    public GameObject questWindow;
    public GameObject dialogueBox;
    public Button questButton;
    public Button itemCompleteButton;
    
    public QuestManager questManager;

    public float walkTime;
    public float waitTime;
    private float waitCounter;
    private float walkCounter;

    private int walkDirection;

    private Animator anim;

    [TextArea(5, 10)]
    public string dialogue;
    public GameObject chatButton;
    public TMP_Text dialogueText;
    public bool returned = false;
    private bool playerInBounds;

    // Quests
    public bool chatDisabled;
    public Button buildButton;
    public Button questMenuButton;
    public Button inventoryExpandButton;

    void Start()
    {
        if (!quest.isCompleted)
        {
            dialogueText.text = dialogue;
        }

        if (quest.isCompleted && quest.isItemQuest)
        {
            dialogueText.text = "Thanks for the " + quest.itemNeeded.itemName + "!";
            returned = true;
        }

        if (quest.isCompleted && !quest.isItemQuest)
        {
            chatDisabled = true;
            disableQuestDialogue();
        }

        chatButton.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);

        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void Update()
    {
        if (quest.isActive && !chatDisabled && !quest.isItemQuest) {
            chatDisabled = true;
            disableQuestDialogue();
        }
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
            if (!chatDisabled)
            {
                playerInBounds = true;
                chatButton.SetActive(true);
                isWalking = false;
                anim.SetBool("isMoving", false);
                anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal") * -1);
                anim.SetFloat("moveY", Input.GetAxisRaw("Vertical") * -1);
                rigidBody.bodyType = RigidbodyType2D.Static; 
            }
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
            questButton.gameObject.SetActive(false);
            itemCompleteButton.gameObject.SetActive(false);
            rigidBody.bodyType = RigidbodyType2D.Dynamic; 
            isWalking = true;
        }
    }

    public void openQuestWindow()
    {
        buildButton.interactable = false;
        questMenuButton.interactable = false;
        inventoryExpandButton.interactable = false;
        dialogueBox.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
        itemCompleteButton.gameObject.SetActive(false);
        questWindow.gameObject.SetActive(true);
        questManager.setQuestDetails(quest);
        returned = true;
    }

    public void completeItemQuest()
    {
        dialogueBox.gameObject.SetActive(false);
        chatButton.SetActive(false);
        questButton.gameObject.SetActive(false);
        itemCompleteButton.gameObject.SetActive(false);
        quest.itemNeeded.count -= quest.amountNeeded;
        GameObject.Find("QuestManager").GetComponent<QuestManager>().completeQuest(quest);
        GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().updateXP(quest.xpReward);
        GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().addMoney(quest.moneyReward);
        quest.isCompleted = true;
        dialogueText.text = "Thanks for the " + quest.itemNeeded.itemName + "!";
    }

    public void disableQuestDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
    }

    public void chat()
    {
            if (quest.isItemQuest && quest.isActive)
            {
                // Update dialogue text
                if (quest.itemNeeded.count < quest.amountNeeded && returned)
                {
                    questButton.gameObject.SetActive(false);
                    dialogueBox.gameObject.SetActive(true);
                    dialogueText.text = "Come back to me when you have " + quest.amountNeeded + " " + quest.itemNeeded.itemName;
                }

                if (!quest.isCompleted && (quest.itemNeeded.count >= quest.amountNeeded) && returned)
                {
                    itemCompleteButton.gameObject.SetActive(true);
                    dialogueBox.gameObject.SetActive(true);
                    dialogueText.text = "It looks like you have enough " + quest.itemNeeded.itemName + "!";
                }
            }

            chatButton.SetActive(false);

            if (!returned)
            {
                dialogueBox.gameObject.SetActive(true);
                questButton.gameObject.SetActive(true);
            }

            if (quest.isItemQuest && quest.isCompleted)
            {
                dialogueBox.gameObject.SetActive(true);
            }
    }
}
