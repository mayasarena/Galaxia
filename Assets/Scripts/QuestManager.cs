using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public QuestScriptableObject[] allQuests;
    public List<QuestScriptableObject> activeQuests;

    public GameObject questWindow;
    public GameObject completeQuestWindow;
    public QuestMenu questMenu;

    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text moneyText;

    public Text completedQuestText;

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
        experienceText.text = quest.xpReward;
        moneyText.text = quest.moneyReward;
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
