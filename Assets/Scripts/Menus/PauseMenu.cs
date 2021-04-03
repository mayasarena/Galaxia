using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public Button buildButton;
    public Button questButton;
    public Button inventoryExpandButton;
    
    void Start()
    {
        pauseMenu.blocksRaycasts = false;
        pauseMenu.alpha = 0;
    }

    void Update()
    {
        // Check if player ever presses Escape button, initiate the escape menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            buildButton.interactable = false;
            questButton.interactable = false;
            inventoryExpandButton.interactable = false;
            pauseMenu.alpha = 1;
            pauseMenu.blocksRaycasts = true;
        }
    }

    // Continue the game if the player presses continue
    public void Continue() {
        Time.timeScale = 1;
        buildButton.interactable = true;
        questButton.interactable = true;
        inventoryExpandButton.interactable = true;
        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
    }

    // Exit the game
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
