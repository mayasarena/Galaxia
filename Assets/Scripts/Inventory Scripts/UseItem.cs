using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private Transform player;
    public ItemScriptableObject itemSO;
    public int healAmount;
    public int energyAmount;
    public AudioSource useAudio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Heal()
    {
        FindObjectOfType<PlayerHealthManager>().HealPlayer(healAmount); // Heal the player
        useAudio.Play();
        itemSO.count -= 1;

        if (itemSO.count < 1)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().interactable = false;
            itemSO.count = 0;
            Destroy(gameObject, useAudio.clip.length);
        }
    }

    public void Energize()
    {
        FindObjectOfType<PlayerStatsManager>().addEnergy(energyAmount); // Heal the player
        useAudio.Play();
        itemSO.count -= 1;

        if (itemSO.count < 1)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().interactable = false;
            Destroy(gameObject, useAudio.clip.length);
            itemSO.count = 0;
        }
    }

    public void Drop()
    {
        // Drop item near player and decrease item count
        Vector3 playerPos = new Vector2(player.position.x, player.position.y + 1);
        itemSO.count -= 1;
        useAudio.Play();
        Instantiate(itemSO.item, playerPos, Quaternion.identity);

        if (itemSO.count < 1)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().interactable = false;
            itemSO.count = 0;
            Destroy(gameObject, useAudio.clip.length);
        }
    }

    private void Update()
    {
        // Update the inventory item amount
        if (itemSO.count > 0 && itemSO.stackable)
        {
            gameObject.transform.Find("countText").GetComponent<Text>().text = itemSO.count.ToString();
        }
    }
}
