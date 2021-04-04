using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool loadPositions;

    void Start()
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
