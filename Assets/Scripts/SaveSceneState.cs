using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSceneState : MonoBehaviour
{

    public List<CraftTypeScriptableObject> craftList;
    public List<float> positionXList;
    public List<float> positionYList;
    public List<int> craftIDList;
    public int numberOfCrafts;

    private static string CRAFT_ID_PREFIX = "craftID_";
    private static string POSX_PREFIX = "posX_";
    private static string POSY_PREFIX = "posY_";

    private int i = 0;

    public void AddPositionAndCraft(int craftID, float x, float y)
    {
        craftIDList.Add(craftID);
        positionXList.Add(x);
        positionYList.Add(y);
    }

    public void SavePositions()
    {
        i = 0;
        foreach(int craftID in craftIDList)
        {
            PlayerPrefs.SetInt(CRAFT_ID_PREFIX + i, craftID);
            i++;
        }
        
        i = 0;
        foreach(int positionX in positionXList)
        {
            PlayerPrefs.SetFloat(POSX_PREFIX + i, positionX);
            i++;
        }

        i = 0;
        foreach(int positionY in positionYList)
        {
            PlayerPrefs.SetFloat(POSY_PREFIX + i, positionY);
            i++;
        }

        PlayerPrefs.SetInt("numberOfCrafts", i + 1);
    }

    public void LoadPositions()
    {
        float posX;
        float posY;
        int craftID;
        // Recreate lists
        for (int i = 0; i < PlayerPrefs.GetInt("numberOfCrafts"); i++)
        {
            posX = PlayerPrefs.GetFloat(POSX_PREFIX + i);
            posY = PlayerPrefs.GetFloat(POSY_PREFIX + i);
            craftID = PlayerPrefs.GetInt(CRAFT_ID_PREFIX + i);

            positionXList.Add(posX);
            positionYList.Add(posY);
            craftIDList.Add(craftID);

            // Instantiate in scene
            foreach (CraftTypeScriptableObject craft in craftList)
            {
                if (craft.ID == craftID)
                {
                    Instantiate(craft.prefab, new Vector2(posX, posY), Quaternion.identity);
                }
            }
        }
    }

}
