using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistNPC : MonoBehaviour
{
    public PlayerInventory playerinv;
    bool AlreadyTalked = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsNearby() && Input.GetKeyDown(KeyCode.E) && !AlreadyTalked)
        {
            playerinv.TalkedToActivist = true;
            AlreadyTalked = false;
        }

        bool PlayerIsNearby()
        {
            return true;
        }
    }
}
