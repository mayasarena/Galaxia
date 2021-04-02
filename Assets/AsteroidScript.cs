using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float Movespeed;
    public bool moveright = false;
    public float Rotationspeed;
    public bool Rotateright = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        
        int flipdirection = Random.Range(0,2);
        if(flipdirection == 1){
            Rotateright = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {  
        if(col.gameObject.name == "Asteroid Deleter" ){
            Destroy(this.gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {  
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Player"  ){
            Destroy(this.gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        //Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        
        if(Rotateright == false){
            this.gameObject.transform.Rotate(Vector3.forward * Rotationspeed);
        }

        else if(Rotateright == true){
            this.gameObject.transform.Rotate(Vector3.forward * -Rotationspeed);
        }
        if (moveright == false){
            this.gameObject.transform.position -= new Vector3(Movespeed, 0, 0);
        }
        else if(moveright == true){
            this.gameObject.transform.position += new Vector3(Movespeed, 0, 0);
        }
        
        
    }
}
