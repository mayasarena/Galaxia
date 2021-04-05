using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool loadPositions;
    public PlayerData playerData;
    public ItemScriptableObject greyRocks;
    public ItemScriptableObject redRocks;

    void Start()
    {
        if (PlayerPrefs.GetInt("startup") == 1)
        {
            GetComponent<SaveAndLoad>().LoadInventoryData();
            GetComponent<SaveAndLoad>().LoadPlayerData();
            greyRocks.count = 15;
            greyRocks.inventorySlots.Add(0);
            redRocks.count = 15;
            redRocks.inventorySlots.Add(1);
            playerData.health = 100;
            playerData.energy = 300;
            playerData.money = 2000;
            PlayerPrefs.SetInt("startup", 0);
        }

        else
        {
            if (loadPositions)
            {
                GetComponent<SaveSceneState>().LoadPositions();
            }
            GetComponent<SaveAndLoad>().LoadInventoryData();
            GetComponent<SaveAndLoad>().LoadPlayerData();
            GetComponent<SaveAndLoad>().LoadQuestData();
        }
    }

}
