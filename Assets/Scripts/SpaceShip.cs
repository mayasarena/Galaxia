using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public GameObject travelButton;
    public QuestScriptableObject spaceShipQuest;

    // Start is called before the first frame update
    void Start()
    {
        
        if (spaceShipQuest.isActive)
        {
            GameObject.Find("QuestManager").GetComponent<QuestManager>().completeQuest(spaceShipQuest);
            GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().updateXP(spaceShipQuest.xpReward);
            GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().addMoney(spaceShipQuest.moneyReward);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            travelButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            travelButton.SetActive(false);
        }
    }
}
