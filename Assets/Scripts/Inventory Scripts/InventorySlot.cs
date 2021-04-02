using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;
    public int i;
    [SerializeField] public ItemScriptableObject item;

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

    public void OnDrop(PointerEventData eventData)
    {
        if (inventory.organize)
        {
            GameObject itemBeingDragged = eventData.pointerDrag; 
            InventorySlot prevSlot = itemBeingDragged.transform.parent.GetComponent<InventorySlot>();
            if (eventData.pointerDrag != null)
            {
                if (inventory.isFull[i] == true)
                {
                    itemBeingDragged.transform.position = itemBeingDragged.transform.parent.position;
                }

                else
                {
                    itemBeingDragged.transform.SetParent(gameObject.transform, false); 
                    itemBeingDragged.transform.position = gameObject.transform.position;
                    // Replace slot
                    if (inventory.isFull[i] == false && (itemBeingDragged.transform.parent != gameObject))
                    {
                        // Replace inventory item
                        inventory.itemScriptableObj[prevSlot.i] = null;
                        inventory.isFull[prevSlot.i] = false;
                        prevSlot.item = null;
                        inventory.itemScriptableObj[i] = itemBeingDragged.GetComponent<UseItem>().itemSO;
                        inventory.isFull[i] = true;
                        ItemScriptableObject itemSO = itemBeingDragged.GetComponent<UseItem>().itemSO;

                        if (itemSO.stackable)
                        {
                            itemSO.inventorySlots[0] = i; 
                        }

                        else{
                            itemSO.inventorySlots.Add(i);
                            itemSO.inventorySlots.RemoveAll(item => item == prevSlot.i);
                        }
                    }
                }
            }
        }
    }
}
