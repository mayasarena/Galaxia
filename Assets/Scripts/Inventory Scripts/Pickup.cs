using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public ItemScriptableObject itemSO;
    public bool containsSameItem;
    public AudioSource pickupAudio;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // Check if player is picking up the item
        if (other.tag == "Player")
        {
            containsSameItem = false;
            // Iterate over inventory slots
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                // If the item is already in the inventory, increase the current amount
                if (inventory.itemScriptableObj[i] == itemSO && itemSO.stackable)
                {
                    pickupAudio.Play();
                    containsSameItem = true;
                    itemSO.count += 1;
                    // Destroy item on ground
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(gameObject, pickupAudio.clip.length);
                    break;
                }
            }

            // Iterate over slots again
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                // If slot is empty and the item is not already in inventory
                if (inventory.isFull[i] == false && (containsSameItem == false || !itemSO.stackable))
                {
                    pickupAudio.Play();
                    // Set inventory as full, set inventory scriptable object
                    inventory.isFull[i] = true;
                    inventory.itemScriptableObj[i] = itemSO;
                    itemSO.count += 1;
                    itemSO.inventorySlots.Add(i);
                    // Instantiate the item button in inventory
                    Instantiate(itemSO.itemButton, inventory.slots[i].transform, false);
                    // Destroy object on ground
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(gameObject, pickupAudio.clip.length);
                    break;
                }
            }
        }
    }

    public void addItemToInventory(ItemScriptableObject itemSO)
        {
        containsSameItem = false;
        // Iterate over inventory slots
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            // If the item is already in the inventory, increase the current amount
            if (inventory.itemScriptableObj[i] == itemSO && itemSO.stackable)
            {
                containsSameItem = true;
                itemSO.count += 1;
                break;
            }
        }

        // Iterate over slots again
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            // If slot is empty and the item is not already in inventory
            if (inventory.isFull[i] == false && (containsSameItem == false || !itemSO.stackable))
            {
                // Set inventory as full, set inventory scriptable object
                inventory.isFull[i] = true;
                inventory.itemScriptableObj[i] = itemSO;
                itemSO.count += 1;
                itemSO.inventorySlots.Add(i);
                // Instantiate the item button in inventory
                Instantiate(itemSO.itemButton, inventory.slots[i].transform, false);
                break;
            }
        }
    }
}
