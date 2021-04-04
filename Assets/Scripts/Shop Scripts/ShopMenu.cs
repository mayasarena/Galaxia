using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public ItemScriptableObject[] itemsForSale;
    public int[] prices;
    [TextArea(3, 10)] 
    public string[] descriptions;
    public int[] xpEarned;
    private PlayerStatsManager playerStatsManager;
    public List<GameObject> buttonList;
    public int selectedItem;
    public GameObject inventoryFullError;
    public TMP_Text confirmationText;
    public AudioSource buyItemAudio;
    public AudioSource fullAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        GameObject currentTemplate;
        GameObject itemTemplate = transform.GetChild(0).gameObject;

        for (int i = 0; i < itemsForSale.Length; i++)
        {
            currentTemplate = Instantiate(itemTemplate, transform);
            currentTemplate.GetComponent<ShopItem>().itemIndex = i;
            currentTemplate.transform.GetChild(0).GetComponent<TMP_Text>().text = itemsForSale[i].itemName;
            currentTemplate.transform.GetChild(1).GetComponent<Image>().sprite = itemsForSale[i].itemSprite;
            currentTemplate.transform.GetChild(2).GetComponent<TMP_Text>().text = descriptions[i];
            currentTemplate.transform.GetChild(3).GetComponent<TMP_Text>().text = prices[i].ToString();
            buttonList.Add(currentTemplate);
        }

        Destroy(itemTemplate);   
    }

    void Update()
    {
        foreach(GameObject button in buttonList)
        {
            for (int i = 0; i < itemsForSale.Length; i++)
            {
                if (playerStatsManager.playerData.money < prices[i])
                {
                    button.GetComponent<Button>().interactable = false;
                    button.GetComponent<CanvasGroup>().alpha = 0.5f;
                }

                else
                {
                    button.GetComponent<Button>().interactable = true;
                    button.GetComponent<CanvasGroup>().alpha = 1f;
                }
            }
        }
    }

    public void BuyItem()
    {
        if (FindObjectOfType<Inventory>().isInventoryFull())
        {
            fullAudio.Play();
            inventoryFullError.SetActive(true);
        }

        else
        {
            buyItemAudio.Play();
            playerStatsManager.subtractMoney(prices[selectedItem]);
            playerStatsManager.updateXP(xpEarned[selectedItem]);
            FindObjectOfType<Pickup>().addItemToInventory(itemsForSale[selectedItem]); // Add to inventory
        }
    }

    public void confirmation()
    {
        confirmationText.text = itemsForSale[selectedItem].itemName;
    }
}
