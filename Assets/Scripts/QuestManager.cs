using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public QuestScriptableObject[] allQuests;
    public List<QuestScriptableObject> activeQuests;

    public GameObject questWindow;
    public QuestMenu questMenu;

    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text moneyText;

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
}
