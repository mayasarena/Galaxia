using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public ItemScriptableObject[] itemScriptableObj;
    public ItemScriptableObject[] initiateObjsList;
    public bool organize;
    public bool inventoryOpen;
    public bool inventoryFull;

    void Start()
    {
        // Check how much of each item the player has in order to initiate the inventory upon start
        foreach (ItemScriptableObject obj in initiateObjsList)
        {
            // If player has over 1 of a certain item, add it to the inventory
            if (obj.count > 0)
            {
                if (obj.stackable)
                {
                    Instantiate(obj.itemButton, slots[obj.inventorySlots[0]].transform, false);
                    itemScriptableObj[obj.inventorySlots[0]] = obj;
                    slots[obj.inventorySlots[0]].GetComponent<InventorySlot>().item = obj; 
                    // Set slot to full
                    isFull[obj.inventorySlots[0]] = true;
                }

                else
                {
                    for (int i = 0; i < obj.inventorySlots.Count; i++)
                    {
                        Instantiate(obj.itemButton, slots[obj.inventorySlots[i]].transform, false);
                        itemScriptableObj[obj.inventorySlots[i]] = obj;
                        slots[obj.inventorySlots[i]].GetComponent<InventorySlot>().item = obj; 
                        // Set slot to full
                        isFull[obj.inventorySlots[i]] = true;
                    }
                }
            }
        }
    }

    public bool isInventoryFull()
    {
        bool full = true;

        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i] == false)
            {
                full = false;
            }
        }
        return full;
    }

    public void turnOnOrganize()
    {
        organize = true;
    }

    public void turnOffOrganize()
    {
        organize = false;
    }

    public void inventoryMenuOpen()
    {
        inventoryOpen = true;
        Time.timeScale = 0;
    }

    public void inventoryMenuClosed()
    {
        inventoryOpen = false;
        Time.timeScale = 1;
    }
}
