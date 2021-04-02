using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject[] Asteroids;
    public PhysicsMaterial2D asteroidmaterial;
    public bool spawnAsts = false;
    public bool spawnRight = false;
    public float Timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("startAsteroids",5);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (this.spawnAsts == true && Timer <= 0f){
            int randomPrefab = Random.Range(0,Asteroids.Length);
            int distanceFromSpawner = Random.Range(-30, 30);
            GameObject spawnedRoid = Asteroids[randomPrefab];
            GameObject container = new GameObject("ASTContainer");
            container.tag = "Asteroid";
            container.layer = LayerMask.NameToLayer("Asteroid");
            
            container.transform.position = new Vector2(this.gameObject.transform.position.x, distanceFromSpawner );
            AsteroidScript Astinfo = container.AddComponent<AsteroidScript>();

            CircleCollider2D asteroidcollider = spawnedRoid.GetComponent<CircleCollider2D>(); //get collider off prefab
            CircleCollider2D containercollider = container.AddComponent<CircleCollider2D>();
            containercollider = asteroidcollider;

          

            Rigidbody2D tempRB = container.AddComponent<Rigidbody2D>();
            tempRB.gravityScale = 0;
            tempRB.mass = 50000;
            tempRB.sharedMaterial = asteroidmaterial;
            
            
            GameObject asteroidinstance = Instantiate(spawnedRoid, new Vector2(container.transform.position.x, container.transform.position.y ), Quaternion.identity);
            asteroidinstance.transform.parent = container.transform;

            float[] speedlist = {0.05f,0.1f,0.2f,0.3f};
            float speedlistselector = speedlist[Random.Range(0,speedlist.Length)];
            
            Astinfo.moveright = this.spawnRight; //set direction equal to spawners
            
            float[] rotspeedlist = {0.5f,0.75f,1,1.25f};
            float rotspeedlistselector = speedlist[Random.Range(0,speedlist.Length)];
            Astinfo.Rotationspeed = 1;
            Astinfo.Movespeed = speedlistselector;
            
            

            Timer = 2f;
        }
    }

    void startAsteroids(){
        this.spawnAsts = true;
    }
}
