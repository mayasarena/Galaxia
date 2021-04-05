using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public List<ItemScriptableObject> itemList;
    public PlayerData playerData;
    public List<QuestScriptableObject> questList;

    private static string ITEM_COUNT_PREFIX = "itemCount_";
    private static string NUM_SLOTS_PREFIX = "numSlots_";
    private static string SLOT_INDEX_PREFIX = "inventorySlotIndex_";
    private static string QUEST_ACTIVE_PREFIX = "questIsActive_";
    private static string QUEST_COMPLETED_PREFIX = "questIsCompleted_";

    private int i = 0;
    private int slotListLength;

    public void Save()
    {
        SaveInventoryData();
        SavePlayerData();
        SaveQuestData();
    }

    public void Load()
    {
        LoadInventoryData();
        LoadPlayerData();
        LoadQuestData();
    }

    public void LoadInventoryData()
    {
        i = 0;
        foreach (ItemScriptableObject item in itemList)
        {
            item.inventorySlots.Clear();
            // Load item count and number of inventory slots
            item.count = PlayerPrefs.GetInt(ITEM_COUNT_PREFIX + i);
            slotListLength = PlayerPrefs.GetInt(NUM_SLOTS_PREFIX + i);

            // Iterate to add inventory slot indexes
            for (int j = 0; j < slotListLength; j++)
            {
                item.inventorySlots.Add(PlayerPrefs.GetInt(SLOT_INDEX_PREFIX + i + j));
            }
            i++;
        }
    }

    public void SaveInventoryData()
    {
        i = 0;
        foreach (ItemScriptableObject item in itemList)
        {
            // Save item count and number of inventory slots
            PlayerPrefs.SetInt(ITEM_COUNT_PREFIX + i, item.count);
            PlayerPrefs.SetInt(NUM_SLOTS_PREFIX + i, item.inventorySlots.Count);

            // Save inventory slot index
            for (int j=0; j < item.inventorySlots.Count; j++)
            {
                PlayerPrefs.SetInt(SLOT_INDEX_PREFIX + i + j, item.inventorySlots[j]);
            }
            i++;
        }
    }

    public void LoadPlayerData()
    {
        playerData.health = PlayerPrefs.GetInt("playerHealth");
        playerData.money = PlayerPrefs.GetInt("playerMoney");
        playerData.totalXP = PlayerPrefs.GetInt("playerTotalXP");
        playerData.levelXP = PlayerPrefs.GetInt("playerLevelXP");
        playerData.level = PlayerPrefs.GetInt("playerLevel");
        playerData.energy = PlayerPrefs.GetInt("playerEnergy");
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("playerHealth", playerData.health);
        PlayerPrefs.SetInt("playerMoney", playerData.money);
        PlayerPrefs.SetInt("playerTotalXP", playerData.totalXP);
        PlayerPrefs.SetInt("playerLevelXP", playerData.levelXP);
        PlayerPrefs.SetInt("playerLevel", playerData.level);
        PlayerPrefs.SetInt("playerEnergy", playerData.energy);
    }

    public void LoadQuestData()
    {
        i = 0;
        foreach (QuestScriptableObject quest in questList)
        {
            quest.isActive = (PlayerPrefs.GetInt(QUEST_ACTIVE_PREFIX + i) != 0);
            print((PlayerPrefs.GetInt(QUEST_ACTIVE_PREFIX + i) != 0));
            quest.isCompleted = (PlayerPrefs.GetInt(QUEST_COMPLETED_PREFIX + i) != 0);
            i++;
        }
    }

    public void SaveQuestData()
    {
        i = 0;
        foreach (QuestScriptableObject quest in questList)
        {
            PlayerPrefs.SetInt(QUEST_ACTIVE_PREFIX + i, (quest.isActive ? 1 : 0));
            PlayerPrefs.SetInt(QUEST_COMPLETED_PREFIX + i, (quest.isCompleted ? 1 : 0));
            i++;
        }
    }
}
