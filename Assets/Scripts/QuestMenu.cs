using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    public QuestManager questManager;
    public CanvasGroup questMenuCanvas;
    public GameObject noActiveQuests;

    void Start()
    {
        questMenuCanvas.blocksRaycasts = false;
        questMenuCanvas.alpha = 0;
    }

    public void deactivateTemplate()
    {
        GameObject questTemplate = transform.GetChild(0).gameObject;
        questTemplate.SetActive(false);
        noActiveQuests.SetActive(true);
    }

    public void updateQuestsMenu()
    {
        GameObject currentTemplate;
        GameObject questTemplate = transform.GetChild(0).gameObject;
        questTemplate.SetActive(true);
        noActiveQuests.SetActive(false);

        foreach (QuestScriptableObject quest in questManager.activeQuests)
        {
            currentTemplate = Instantiate(questTemplate, transform);
            currentTemplate.transform.GetChild(0).GetComponent<Text>().text = quest.title;
            currentTemplate.transform.GetChild(1).GetComponent<Text>().text = quest.description;
        }

        Destroy(questTemplate);
    }

    public void Open()
    {
        questMenuCanvas.blocksRaycasts = true;
        questMenuCanvas.alpha = 1;
    }

    public void Close() {
        questMenuCanvas.blocksRaycasts = false;
        questMenuCanvas.alpha = 0;
    }
    
}
