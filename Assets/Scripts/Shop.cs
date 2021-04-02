using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject clickText;
    public bool playerInBounds;
    public CanvasGroup shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        shopMenu.blocksRaycasts = false;
        shopMenu.alpha = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerInBounds)
        {
            clickText.SetActive(false);
            shopMenu.blocksRaycasts = true;
            shopMenu.alpha = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.SetActive(true);
            playerInBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.SetActive(false);
            playerInBounds = false;
        }
    }
}
