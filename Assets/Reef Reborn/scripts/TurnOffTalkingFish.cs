using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAfterTalk : MonoBehaviour
{
    private PlayerDialogue playerDialogue;
    public GameObject talkIcon;

    private bool playerInRange = false;
    private bool wasSpeaking = false;
    private bool hasTalked = false;

    private Collider2D[] colliders;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            playerDialogue = player.GetComponent<PlayerDialogue>();

        colliders = GetComponentsInChildren<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerDialogue == null || hasTalked) return;

        // when THIS NPC starts being used
        if (playerInRange && playerDialogue.IsSpeaking())
        {
            wasSpeaking = true;
        }

        // when THIS NPC finishes
        if (playerInRange && wasSpeaking && !playerDialogue.IsSpeaking())
        {
            hasTalked = true;

            // turn off E
            if (talkIcon != null)
                talkIcon.SetActive(false);

            // disable ALL colliders
            foreach (Collider2D col in colliders)
            {
                if (col != null)
                    col.enabled = false;
            }
        }
    }
}