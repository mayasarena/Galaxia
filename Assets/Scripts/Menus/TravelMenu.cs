using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelMenu : MonoBehaviour
{
    public CanvasGroup travelMenu;
    public GameObject travelButton;
    public AudioSource openAudio;
    
     void Start()
    {
        travelMenu.blocksRaycasts = false;
        travelMenu.alpha = 0;
    }

    public void Open()
    {
        openAudio.Play();
        travelButton.SetActive(false);
        travelMenu.blocksRaycasts = true;
        travelMenu.alpha = 1;
    }

    // Exit the game
    public void Close()
    {
        travelMenu.alpha = 0;
        travelMenu.blocksRaycasts = false;
    }
}
