using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int itemIndex;

    public void selectItem()
    {
        FindObjectOfType<ShopMenu>().selectedItem = itemIndex;
    }
}
