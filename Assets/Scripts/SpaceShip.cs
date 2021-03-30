using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public Text clickText;
    public bool playerInBounds;
    public TravelMenu travelMenu;
    public QuestScriptableObject spaceShipQuest;

    // Start is called before the first frame update
    void Start()
    {
        travelMenu = GameObject.Find("Travel Menu").GetComponent<TravelMenu>();
        clickText.gameObject.SetActive(false);
        
        if (spaceShipQuest.isActive)
        {
            GameObject.Find("QuestManager").GetComponent<QuestManager>().completeQuest(spaceShipQuest);
            GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().updateXP(spaceShipQuest.xpReward);
            GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>().addMoney(spaceShipQuest.moneyReward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerInBounds)
        {
            clickText.gameObject.SetActive(false);
            travelMenu.Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.gameObject.SetActive(true);
            playerInBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player enters chatting bounds, stop and face player
        // Enable chat UI
        if (other.tag == "Player")
        {
            clickText.gameObject.SetActive(false);
            playerInBounds = false;
        }
    }
}
