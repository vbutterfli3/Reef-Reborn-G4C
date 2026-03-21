using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorNPC : MonoBehaviour
{
    public PlayerInventory playerinv;
    bool AlreadyTalked = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsNearby() && Input.GetKeyDown(KeyCode.E) && !AlreadyTalked)
        {
            playerinv.TalkedToMayor = true;
            AlreadyTalked = false;
        }

        bool PlayerIsNearby()
        {
            return true;
        }
    }
}