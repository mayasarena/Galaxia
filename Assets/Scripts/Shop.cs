using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text clickText;
    public bool playerInBounds;
    public GameObject shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        shopMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerInBounds)
        {
            clickText.gameObject.SetActive(false);
            shopMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.gameObject.SetActive(true);
            playerInBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.gameObject.SetActive(false);
            playerInBounds = false;
        }
    }
}
