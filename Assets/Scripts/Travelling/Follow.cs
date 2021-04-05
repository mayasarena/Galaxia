using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public float MinDist = 5;
    float Timer = 0.0f;
    public int shotTimer = 3;
    public bool is_shooter = false;
    public GameObject Projectile;
    private bool playerinrange = false;
 
 
    void Start () 
    {
    Player = GameObject.Find("Player");

    }
 
    void FixedUpdate () 
    {
    if(playerinrange == true){
        Transform PlayerTF = Player.transform;
        Timer += Time.deltaTime;
        if(Vector2.Distance(transform.position,PlayerTF.position) >= MinDist){
        
            transform.position = Vector2.MoveTowards(transform.position,Player.transform.position, MoveSpeed*Time.deltaTime);
        
        }
        if(Vector2.Distance(transform.position,PlayerTF.position) <= MaxDist )
            { //Here Call any function U want Like Shoot at here or something
                if(is_shooter == true){
                    if(Timer > shotTimer){
                        shootProjectile(Projectile);
                    Timer = 0;
                    }
                    
                }
                
            }
    }else{

    }
 }

    void OnTriggerEnter2D(Collider2D col){ //awake if in vision range
        if (col.gameObject.tag == "Player"){
            playerinrange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){ //sleep when out of range
        if (col.gameObject.tag == "Player"){
            playerinrange = false;
        }
    }

    void shootProjectile(GameObject object_to_shoot){
        GameObject bulletPrefab = Instantiate(object_to_shoot, new Vector2(transform.position.x,transform.position.y), Quaternion.identity);
        Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());
    }



}
