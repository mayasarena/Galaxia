using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public QuestScriptableObject[] allQuests;
    public List<QuestScriptableObject> activeQuests;

    public GameObject questWindow;
    public GameObject completeQuestWindow;
    public Button buildButton;
    public Button questButton;
    public Button inventoryExpandButton;
    public QuestMenu questMenu;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text experienceText;
    public TMP_Text moneyText;

    public TMP_Text completedQuestText;

    public QuestScriptableObject selectedQuest;

    void Start()
    {
        for (int i = 0; i < allQuests.Length; i++)
        {
            if (allQuests[i].isActive == true)
            {
                activeQuests.Add(allQuests[i]);
            }
        }

        if (activeQuests.Count > 0)
        {
            // Instantiate the quests menu
            questMenu.updateQuestsMenu();
        }

        else 
        {
            questMenu.deactivateTemplate();
        }
    }

    public void setQuestDetails(QuestScriptableObject quest)
    {
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.xpReward.ToString();
        moneyText.text = quest.moneyReward.ToString();
        selectedQuest = quest;
    }

    public void acceptQuest()
    {
        buildButton.interactable = true;
        questButton.interactable = true;
        inventoryExpandButton.interactable = true;
        selectedQuest.isActive = true;
        activeQuests.Add(selectedQuest);
        questWindow.gameObject.SetActive(false);
        questMenu.updateQuestsMenu();
    }

    public void completeQuest(QuestScriptableObject quest)
    {
        quest.isActive = false;
        quest.isCompleted = true;
        activeQuests.Remove(quest);
        questMenu.updateQuestsMenu();
        completedQuestText.text = quest.title;
        buildButton.interactable = false;
        questButton.interactable = false;
        inventoryExpandButton.interactable = false;
        completeQuestWindow.gameObject.SetActive(true);
    }

    public void closeCompleteQuestWindow()
    {
        buildButton.interactable = true;
        questButton.interactable = true;
        inventoryExpandButton.interactable = true;
        completeQuestWindow.SetActive(false);
    }
}
