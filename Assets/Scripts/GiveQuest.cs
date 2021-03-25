using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public QuestScriptableObject quest;

    public GameObject questWindow;
    public GameObject dialogueBox;
    public Button questButton;
    
    public QuestManager questManager;

    public void openQuestWindow()
    {
        dialogueBox.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
        questWindow.gameObject.SetActive(true);
        questManager.setQuestDetails(quest);
    }

    public void disableQuestDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
    }
}
