using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Perlinwalls : MonoBehaviour
{
    public Tilemap map;
    //public TileBase platform;
    public TileBase wall;
    public int seed;
    public int seedindex = 0;
    public float freq;

    void Awake(){
    Tilemap tilemap = GetComponent<Tilemap>();
        GameObject SeedGO = GameObject.Find("Seed Manager");
        SeedManager seedman = SeedGO.GetComponent<SeedManager>();
        seed = seedman.seedlist[seedindex];
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        Debug.Log("Bounds x min" + bounds.xMin);
        Debug.Log("Bounds y min" + bounds.yMin);
        //Debug.Log("Bounds x min" + bounds.xMin);
       
        for (int x = bounds.xMin; x < bounds.xMax; x++) {
            for (int y = bounds.yMin; y < bounds.yMax; y++) {
                float perlin = Mathf.PerlinNoise( (((x + seed) ) * freq), (((y  + seed )) * freq ) );
                if(perlin < 0.3  ){
                    tilemap.SetTile(new Vector3Int(x, y, 0), wall);
                    }
                else{
                    
                }
            }
        }
    //tilemap.SetTile(bounds.center, platform);      
    }
}
