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
        completeQuestWindow.gameObject.SetActive(true);
        completedQuestText.text = quest.title;
    }

    public void closeCompleteQuestWindow()
    {
        completeQuestWindow.SetActive(false);
    }
}
