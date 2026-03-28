using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistNPC : MonoBehaviour
{
    public PlayerInventory playerinv;
    public GameObject TalkIcon;
    public  bool AlreadyTalked = false;
    public float interactDistance = 3f;
  

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerinv.transform.position);

        if (distance < interactDistance && Input.GetKeyDown(KeyCode.E) && !AlreadyTalked)
        {
            playerinv.TalkedToActivist = true;
            AlreadyTalked = true;

            GetComponent<CircleCollider2D>().enabled = false;
            TalkIcon.SetActive(false);
            playerinv.Level();
            }
        }
    }
