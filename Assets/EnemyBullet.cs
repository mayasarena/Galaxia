using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float moveSpeed = 0.5f;
    Rigidbody2D rb;
    GameObject target;
    Vector2 moveDirection;
    public bool shootOverWalls = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target =  GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 5f);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Environment")
        {
            if(shootOverWalls == false){
                Destroy(gameObject);
            }
            
        }
        

        
    }
    
}