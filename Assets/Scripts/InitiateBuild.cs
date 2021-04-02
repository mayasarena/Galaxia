using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateBuild : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] public CraftTypeScriptableObject craftTypeSO;

    // Set currently selected craft
    public void SetCraft()
    {
        buildingManager.SetActiveCraft(craftTypeSO);
    }

    // Set isCraftSelected to true
    public void SetBool()
    {
        buildingManager.SetIsCraftSelected(true);
    }
}
