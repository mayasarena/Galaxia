using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Perlinwalls : MonoBehaviour
{
    public Tilemap map;
    public GameObject Player;
    //public TileBase platform;
    public Vector2 PlayerSpawn;
    public TileBase wall;
    public int seed;
    public GameObject[] EnemyList;
    public int NumbEnemies;
    public int seedindex = 0;
    public float freq;
    public float Timer = 15f;
    public List<Vector2> goodspawns;
    // Start is called before the first frame update
    

    void Awake(){
        Tilemap tilemap = GetComponent<Tilemap>();
        GameObject SeedGO = GameObject.Find("SeedManager");
        SeedManager seedman = SeedGO.GetComponent<SeedManager>();
        goodspawns = new List<Vector2>();
        //seed = seedman.seedlist[seedindex];

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        Debug.Log("Bounds x min" + bounds.xMin);
        Debug.Log("Bounds y min" + bounds.yMin);
        //Debug.Log("Bounds x min" + bounds.xMin);
       
        for (int x = bounds.xMin + 3; x < bounds.xMax - 3; x++) {
            for (int y = bounds.yMin + 3; y < bounds.yMax - 3; y++) {
                float perlin = Mathf.PerlinNoise( (((x + seed) ) * freq), (((y  + seed )) * freq ) );
                if(perlin < 0.3  ){
                    tilemap.SetTile(new Vector3Int(x, y, 0), wall);
                    }
                else{
                    Vector2 safespotfound = new Vector2(x,y);
                    goodspawns.Add(safespotfound);
                }
            }
        }
        int playerspawnselector = Random.Range(0, goodspawns.Count); 
        if(PlayerSpawn == null){
            PlayerSpawn = goodspawns[playerspawnselector];
            goodspawns.Remove(goodspawns[playerspawnselector]);
        }
        
        for(int i = 0; i < NumbEnemies; i++){
            int EnemyTypeselector = Random.Range(0, EnemyList.Length);
            GameObject enemytospawn = EnemyList[EnemyTypeselector]; //get random enemy to spawn

            int EnemyPositionselector = Random.Range(0, goodspawns.Count); //get position from list
            Vector2 enemyspawnpoint = goodspawns[EnemyPositionselector];
            if(Vector2.Distance(enemyspawnpoint,PlayerSpawn) < 20){
                i--;
            }
            Instantiate(enemytospawn, enemyspawnpoint, Quaternion.identity);
            goodspawns.Remove(goodspawns[EnemyPositionselector]);
        }
    //tilemap.SetTile(bounds.center, platform);      
    }
    

    // Update is called once per frame
    void Update(){
    Timer -= Time.deltaTime;
    if(Timer <= 0){
        int EnemyTypeselector = Random.Range(0, EnemyList.Length);
        GameObject enemytospawn = EnemyList[EnemyTypeselector]; //get random enemy to spawn
        
        int EnemyPositionselector = Random.Range(0, goodspawns.Count); //get position from list
        Vector2 enemyspawnpoint = goodspawns[EnemyPositionselector];

        Instantiate(enemytospawn, enemyspawnpoint, Quaternion.identity);
        Timer = 15f;
    }
    }
    
    //void setSpawn(){

    //}

    
}