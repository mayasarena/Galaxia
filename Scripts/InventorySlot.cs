using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    [SerializeField] private ItemScriptableObject item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void Update()
    {
        // Check if inventory slot is empty
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
            inventory.itemScriptableObj[i] = null;
        }

        // Set slot item
        else
        {
            item = inventory.itemScriptableObj[i]; 
        }
    }
}
