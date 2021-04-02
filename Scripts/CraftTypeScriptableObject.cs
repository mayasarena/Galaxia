using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class CraftTypeScriptableObject : ScriptableObject 
{
    public Transform prefab;
    public GameObject template;
    public ItemScriptableObject[] itemsNeeded;
    public int[] amountNeeded;
}
