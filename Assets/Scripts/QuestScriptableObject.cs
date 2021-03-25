using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class QuestScriptableObject : ScriptableObject
{
    public bool isActive;
    public string title;
    [TextArea(5, 10)]
    public string description;

    [Header("Include REWARD: and XP:")]
    [Header("These are strings")]
    public string moneyReward;
    public string xpReward;
}
