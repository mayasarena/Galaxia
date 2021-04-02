using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject[] objects;
   public float amountToSpawn;
   private Vector3 position;
   public float positionStartRangeX;
   public float positionEndRangeX;
   public float positionStartRangeY;
   public float positionEndRangeY;
   private int index;
   
   void Awake()
   {    
       // Spawn items randomly on game load
        for (int i = 0; i <= amountToSpawn; i++)
        {
            position = new Vector3(Random.Range(positionStartRangeX, positionEndRangeX), Random.Range(positionStartRangeY, positionEndRangeY), 0f);
            index = (Random.Range(0, objects.Length));
            Instantiate(objects[index], position, Quaternion.identity);
        }
   }
}
