using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class QuestScriptableObject : ScriptableObject
{
    public bool isActive;
    public bool isCompleted;
    public string title;
    [TextArea(5, 10)]
    public string description;

    public int moneyReward;
    public int xpReward;

    public bool isItemQuest;
    public ItemScriptableObject itemNeeded;
    public int amountNeeded;
}
