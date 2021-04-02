using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public float orthoSize;
    public float smooth;
  
    void Start()
    {
        Camera.main.orthographicSize = orthoSize;
    }

    void LateUpdate () 
    {
        if (transform.position != player.position)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, transform.position.z); // Camera follows player
            playerPos.x = Mathf.Clamp(playerPos.x, minPosition.x, maxPosition.x); // Camera stops at bounds
            playerPos.y = Mathf.Clamp(playerPos.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, playerPos, smooth);
        }
    }
}
