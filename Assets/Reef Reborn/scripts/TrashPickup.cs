using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public int trashSize = 1;

    private bool playerNearby = false;
    private PlayerInventory inventory;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E)) //only when near and press e 
        {
            if (inventory.TryAddTrash(trashSize))
            {
                Destroy(gameObject); // remove trash from scene
            }
            else
            {
                Debug.Log("Inventory Full"); // cant add
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            inventory = collision.GetComponent<PlayerInventory>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}