using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public int[] seedlist;

    // Start is called before the first frame update
    void Awake()
    {
        seedlist = new int[3];
        for(int i = 0; i < seedlist.Length; i++){
            seedlist[i] = Random.Range(10000,30000);
        }
    }
}