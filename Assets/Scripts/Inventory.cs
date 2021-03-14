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


    void Start()
    {
        // Check how much of each item the player has in order to initiate the inventory upon start
        foreach (ItemScriptableObject obj in initiateObjsList)
        {
            // If player has over 1 of a certain item, add it to the inventory
            if (obj.count > 0)
            {
                // Iterate over inventory slots to find an empty one
                for (int i = 0; i < slots.Length; i++)
                {
                    // If slot is empty, instantiate the inventory item button
                    if (isFull[i] == false)
                    {
                        Instantiate(obj.itemButton, slots[i].transform, false);
                        itemScriptableObj[i] = obj;
                        // Set slot to full
                        isFull[i] = true;
                        break;
                    }
                }
            }
        }
    }
}
