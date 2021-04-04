using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 entrancePosition;
    public VectorValueScriptableObject entrancePositionVector;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            FindObjectOfType<GameManager>().GetComponent<SaveAndLoad>().Save();
            FindObjectOfType<GameManager>().GetComponent<SaveSceneState>().SavePositions();
            entrancePositionVector.value = entrancePosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
