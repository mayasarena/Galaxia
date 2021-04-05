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

    public void Planet1()
    {
        FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
        FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
        SceneManager.LoadScene("Planet1");
    }

    public void Planet2()
    {
        FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
        FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
        SceneManager.LoadScene("Planet2");
    }

    public void Planet3()
    {
        FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
        FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
        SceneManager.LoadScene("Planet3");
    }

    public void Space()
    {
        FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
        FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
        SceneManager.LoadScene("Space");
    }
}
