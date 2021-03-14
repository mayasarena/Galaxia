using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public int count;
    public GameObject item;
    public GameObject itemButton;
}
