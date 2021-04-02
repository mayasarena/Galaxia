using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    public Transform player;
    [SerializeField] private ItemScriptableObject itemSO;
    public AudioClip buttonAudio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Drop()
    {
        AudioSource.PlayClipAtPoint(buttonAudio, Vector3.zero, 1.0f);  
        // Drop item near player and decrease item count
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 1);
        
        itemSO.count -= 1;
        Instantiate(itemSO.item, playerPos, Quaternion.identity);

        // Just for good measure.. make sure any amount below 0 is set to 0 (can't have negative items)
        if (itemSO.count < 1)
        {
            itemSO.count = 0;
        }
    }

    private void Update()
    {
        // Update the inventory item amount
        if (itemSO.count > 0)
        {
            gameObject.transform.Find("countText").GetComponent<Text>().text = itemSO.count.ToString();
        }

        // Destroy inventory item if there's zero of that item count
        if (itemSO.count == 0)
        {
            Destroy(gameObject);
        }
    }
}
