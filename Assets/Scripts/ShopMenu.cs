using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public ItemScriptableObject[] itemsForSale;
    public int[] prices;
    public string[] descriptions;
    public int[] XPearned;
    private PlayerData playerData;
    private List<GameObject> buttonList;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentTemplate;
        playerData = FindObjectOfType<PlayerHealthManager>().playerData;
        GameObject itemTemplate = transform.GetChild(0).gameObject;

        for (int i = 0; i < itemsForSale.Length; i++)
        {
            currentTemplate = Instantiate(itemTemplate, transform);
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
                if (playerData.money < prices[i])
                {
                    button.GetComponent<Button>().interactable = false;
                }

                else
                {
                    button.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    void BuyItem(int index)
    {

    }
}
