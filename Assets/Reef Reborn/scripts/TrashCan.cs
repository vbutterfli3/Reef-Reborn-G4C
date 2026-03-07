using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
   private bool playerNearby = false;
    private PlayerInventory inventory;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E)) //only when near and press e 
        {
            inventory.ThrowOutTrash();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            inventory = collision.GetComponent<PlayerInventory>();
            inventory.ChangeSprite(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            inventory.ChangeSprite(false);
        }
    }
}