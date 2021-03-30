using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class CraftTypeScriptableObject : ScriptableObject 
{
    public string craftName;
    public Transform prefab;
    public GameObject template;
    public Sprite craftSprite;
    public int price;
    public ItemScriptableObject[] itemsNeeded;
    public int[] amountNeeded;
}
