using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class QuestScriptableObject : ScriptableObject 
{
    public Text questDescription;
    public bool completed;
    public GameObject itemButton;
}
