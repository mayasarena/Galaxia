using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool loadPositions;
    public PlayerData playerData;
    public GameObject presents;

    void Start()
    {
        print(PlayerPrefs.GetInt("startup"));
        if (PlayerPrefs.GetInt("startup") == 0)
        {
            presents.SetActive(true);
            playerData.health = 100;
            playerData.energy = 300;
            playerData.money = 3000;
            PlayerPrefs.SetInt("startup", 1);
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
