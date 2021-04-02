using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSpace : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 movement;
    private AudioSource Audiodata;
    private Rigidbody2D rigidBody;
    private Animator anim;
    private bool isMoving;
    public float maxSpeed = 3;
    GameObject trailobject;

    void Awake(){
        Audiodata = this.gameObject.GetComponent<AudioSource>();
        Audiodata.Play(0);

    }

    void Start()
    {
        trailobject = this.gameObject.transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.5f, 0.5f, 0.5f);
        Audiodata.Pause();
        trailobject.SetActive(false);
    }

    void Update()
    {
        // Get player movement
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement = movement * moveSpeed;
        
        
        
        
        // Check if player is idle
        if ( Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f )
        {
            isMoving = false;
            Audiodata.Stop();
            trailobject.SetActive(false);
        }
        // Check if player is moving, set animation
        else
        {
            isMoving = true;
            trailobject.SetActive(true);
            if( (!Audiodata.isPlaying) && isMoving == true ){
                Audiodata.Play();
            }
            else if(Audiodata.isPlaying && isMoving == false)  {
                //Audiodata.Stop();
            }

            else{
                
            }
            anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));

        }
        
        anim.SetBool("isMoving", isMoving);

        
        
        //Vector3 velocity = movement.normalized * moveSpeed;
        
    }

    void FixedUpdate()
    {
        // Make the player move
        //float vert = Input.GetAxisRaw("Vertical");
        //float horz = Input.GetAxisRaw("Horizontal");
        //rigidBody.AddForce(transform.up += vert);
        //rigidBody.AddForce(transform.right += horz);
        //this.transform.position +=  (direction * moveSpeed * Time.deltaTime);
        ForceMode2D mode = ForceMode2D.Force;
        rigidBody.AddRelativeForce(movement,mode);
        
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxSpeed);  
    }
}
