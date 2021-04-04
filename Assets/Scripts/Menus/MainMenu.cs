using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Vector2 spawnPoint;
    public VectorValueScriptableObject spawnPositionVector;
    public int maxEnergy;
    public int maxHealth = 100;

    // When Start is clicked, load the game scene
    public void LoadStart()
    { 
        spawnPositionVector.value = spawnPoint;
        SceneManager.LoadScene("HouseInterior");
    }

    // Exit
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("playerEnergy", maxEnergy);
        PlayerPrefs.SetInt("playerHealth", maxHealth);
    }
}
