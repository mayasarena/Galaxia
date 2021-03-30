using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public PlayerData playerData;
    public Slider slider;
    public Text levelAmountText;
    public Text moneyAmountText;
    public Text totalXPText;
    public int levelXPNeeded;
    public int levelIncreaseRate;

    void Start()
    {
        levelXPNeeded = (int) (Mathf.Pow(playerData.level, 2))*levelIncreaseRate;
        slider.maxValue = levelXPNeeded;
        slider.value = playerData.levelXP;
        totalXPText.text = playerData.totalXP.ToString();
        levelAmountText.text = playerData.level.ToString();
        moneyAmountText.text = playerData.money.ToString();
    }

    public void updateXP(int xpAmount)
    {
        playerData.totalXP += xpAmount;
        playerData.levelXP += xpAmount;
        levelXPNeeded = (int) (Mathf.Pow(playerData.level, 2))*levelIncreaseRate;

        if (playerData.levelXP >= levelXPNeeded)
        {
            playerData.levelXP = playerData.levelXP - levelXPNeeded;
            playerData.level += 1;
            levelAmountText.text = playerData.level.ToString();
            levelXPNeeded = (int) (Mathf.Pow(playerData.level, 2))*levelIncreaseRate;
            slider.maxValue = levelXPNeeded;
        }
        slider.value = playerData.levelXP;
    }

    public void addMoney(int moneyAmount)
    {
        playerData.money += moneyAmount;
        moneyAmountText.text = playerData.money.ToString();
    }

    public void subtractMoney(int moneyAmount)
    {
        playerData.money -= moneyAmount;
        moneyAmountText.text = playerData.money.ToString();
    }
}
