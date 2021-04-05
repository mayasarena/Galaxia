using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroySeedManager : MonoBehaviour
{
    public GameObject seedManager;
    
    void Awake() {

        seedManager = GameObject.Find("SeedManager");

        if (seedManager == null)
        {
            seedManager = this.gameObject;
            seedManager.name = "SeedManager";
            DontDestroyOnLoad(seedManager);

        }
         
        else
        {
            if (this.gameObject.name != "SeedManager")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
