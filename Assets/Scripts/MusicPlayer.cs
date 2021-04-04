using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public GameObject musicPlayer;
    void Awake() {

        musicPlayer = GameObject.Find("BGMusic");

        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "BGMusic";
            DontDestroyOnLoad(musicPlayer);

        }
         
        else
        {
            if (this.gameObject.name != "BGMusic")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
