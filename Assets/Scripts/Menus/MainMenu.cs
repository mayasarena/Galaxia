using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // When Start is clicked, load the game scene
    public void LoadStart()
    { 
        SceneManager.LoadScene(1);
    }

    // Exit
    public void QuitGame()
    {
        Application.Quit();
    }
}
