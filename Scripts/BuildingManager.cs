using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private CraftTypeScriptableObject activeCraftType;
    private Vector2 mousePos;
    private GameObject target;
    public bool isCraftSelected = false;
    public bool instantiate = false;
    private SpriteRenderer sprite_renderer;

    private ItemScriptableObject[] itemSOList;
    private int[] amountList;
    private int amountNeeded;

    public AudioSource buildAudio;

    private void Update()
    {
        // Check if a craft is selected from the menu
        if (isCraftSelected == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            sprite_renderer = activeCraftType.template.GetComponent<SpriteRenderer>();
            BoxCollider2D craftBoxCollider2D = activeCraftType.prefab.GetComponent<BoxCollider2D>();

            // Make the craft template follow the mouse
            if (instantiate == false)
            {
                target = (GameObject)Instantiate(activeCraftType.template);
                instantiate = true;
            }

            target.transform.position = position;

            // If user right clicks, cancel craft
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(target);
                instantiate = false;
                isCraftSelected = false;
            }

            // If user left clicks, place craft
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                // Check if craft can be spawned
                if (CanSpawnCraft(activeCraftType, mousePos))
                {
                    buildAudio.Play();
                    itemSOList = activeCraftType.itemsNeeded;
                    amountList = activeCraftType.amountNeeded;

                    // Decrease inventory items
                    for (int i = 0; i < itemSOList.Length; i++)
                    {
                        amountNeeded = amountList[i];
                        itemSOList[i].count -= amountNeeded;
                    }

                    instantiate = false;
                    Destroy(target);
                    // Place craft down
                    Instantiate(activeCraftType.prefab, position, Quaternion.identity);
                    isCraftSelected = false;
                }
            }   
        }
    }

    // Set currently selected craft type
    public void SetActiveCraft(CraftTypeScriptableObject craftTypeSO)
    {
        activeCraftType = craftTypeSO;
    }

    // See if a craft is currently selected
    public void SetIsCraftSelected(bool b)
    {
        isCraftSelected = b;
    }

    // Check if the craft can be spawned in a location
    private bool CanSpawnCraft(CraftTypeScriptableObject craftTypeSO, Vector2 position)
    {
        BoxCollider2D craftBoxCollider2D = craftTypeSO.prefab.GetComponent<BoxCollider2D>();
        if (Physics2D.OverlapBox(position + (Vector2)craftBoxCollider2D.offset, craftBoxCollider2D.size, 0) != null)
        {
            return false;
        } else
        {
            return true;
        }

    }

    public void cancelCraft()
    {
        Destroy(target);
        instantiate = false;
        isCraftSelected = false;
    }
}
