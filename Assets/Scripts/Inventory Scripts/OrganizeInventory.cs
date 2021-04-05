using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrganizeInventory : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Button itemButton;
    private RectTransform rectTransform;    
    [SerializeField] private Canvas canvas;
    public CanvasGroup canvasGroup;
    public InventorySlot currentSlot;
    private Inventory inventory;

    private void Awake()
    {
        itemButton = gameObject.GetComponent<Button>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvas = GameObject.Find("HotBar").GetComponent<Canvas>(); 
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        if (inventory.organize == true || inventory.inventoryOpen)
        {
            itemButton.enabled = false;
        }

        else 
        {
            itemButton.enabled = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (inventory.organize)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.8f;
            currentSlot = gameObject.transform.parent.GetComponent<InventorySlot>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inventory.organize)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inventory.organize)
        {
            gameObject.transform.position = gameObject.transform.parent.position;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
    }
}
