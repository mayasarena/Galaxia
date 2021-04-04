using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shopButton;
    public CanvasGroup shopMenu;

    public Button buildButton;
    public Button questButton;
    public Button inventoryExpandButton;

    public AudioSource shopAudio;

    // Start is called before the first frame update
    void Start()
    {
        shopButton.SetActive(false);
        shopMenu.blocksRaycasts = false;
        shopMenu.alpha = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            shopButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            shopButton.SetActive(false);
        }
    }

    public void openShop()
    {
        shopAudio.Play();
        buildButton.interactable = false;
        questButton.interactable = false;
        inventoryExpandButton.interactable = false;
        shopMenu.blocksRaycasts = true;
        shopMenu.alpha = 1;
    }
}
