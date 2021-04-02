using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private Transform player;
    public ItemScriptableObject itemSO;
    public AudioClip buttonAudio;
    public int healAmount;
    public int energyAmount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Heal()
    {
        AudioSource.PlayClipAtPoint(buttonAudio, Vector3.zero, 1.0f);  

        FindObjectOfType<PlayerHealthManager>().HealPlayer(healAmount); // Heal the player

        itemSO.count -= 1;

        // Just for good measure.. make sure any amount below 0 is set to 0 (can't have negative items)
        if (itemSO.count < 1)
        {
            itemSO.count = 0;
        }

        if (!itemSO.stackable)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            Destroy(gameObject);
        }
    }

    public void Energize()
    {
        AudioSource.PlayClipAtPoint(buttonAudio, Vector3.zero, 1.0f);  

        FindObjectOfType<PlayerStatsManager>().addEnergy(energyAmount); // Heal the player

        itemSO.count -= 1;

        // Just for good measure.. make sure any amount below 0 is set to 0 (can't have negative items)
        if (itemSO.count < 1)
        {
            itemSO.count = 0;
        }

        if (!itemSO.stackable)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        AudioSource.PlayClipAtPoint(buttonAudio, Vector3.zero, 1.0f);  
        // Drop item near player and decrease item count
        Vector3 playerPos = new Vector2(player.position.x, player.position.y + 1);
        itemSO.count -= 1;
        Instantiate(itemSO.item, playerPos, Quaternion.identity);

        // Just for good measure.. make sure any amount below 0 is set to 0 (can't have negative items)
        if (itemSO.count < 1)
        {
            itemSO.count = 0;
        }

        if (!itemSO.stackable)
        {
            itemSO.inventorySlots.RemoveAll(item => item == gameObject.transform.parent.GetComponent<InventorySlot>().i);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Update the inventory item amount
        if (itemSO.count > 0 && itemSO.stackable)
        {
            gameObject.transform.Find("countText").GetComponent<Text>().text = itemSO.count.ToString();
        }

        // Destroy inventory item if there's zero of that item count
        if (itemSO.count == 0 && itemSO.stackable)
        {
            itemSO.inventorySlots.RemoveAt(0);
            Destroy(gameObject);
        }
    }
}
