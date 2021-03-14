using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonList;
    private ItemScriptableObject[] itemSOList;
    private int[] amountList;
    private int itemCount;
    private int amountNeeded;
    private bool notEnough;
    private CraftTypeScriptableObject craftType;

    private void Update()
    {
        // Check which crafts are buildable
        // Iterate through craft button list
        foreach (GameObject button in buttonList)
        {
            notEnough = false;
            craftType = button.GetComponent<InitiateBuild>().craftTypeSO;
            itemSOList = craftType.itemsNeeded;
            amountList = craftType.amountNeeded;

            // Iterate over items needed, check amount needed
            for (int i = 0; i < itemSOList.Length; i++)
            {
                itemCount = itemSOList[i].count;
                amountNeeded = amountList[i];

                // If player doesn't have enough items, disable the craft button
                if (itemCount < amountNeeded)
                {
                    button.GetComponent<Button>().interactable = false;
                    button.GetComponent<CanvasGroup>().alpha = 0.5f;
                    notEnough = true;
                }
            }

            // If player has enough items, enable button
            if (!notEnough)
            {
                button.GetComponent<Button>().interactable = true;
                button.GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }
}
