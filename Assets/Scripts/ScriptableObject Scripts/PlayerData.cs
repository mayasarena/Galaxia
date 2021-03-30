using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerData : ScriptableObject
{
    public int health;
    public int money;
    public int totalXP;
    public int levelXP;
    public int level;
}
