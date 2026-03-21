using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterNPC : MonoBehaviour
{
    public PlayerInventory playerinv;
    bool supported = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsNearby() && Input.GetKeyDown(KeyCode.E) && !supported)
        {
            playerinv.supporterCount++;
            supported = true;
        }
        
    }
    bool PlayerIsNearby ()
    {
        return true; 
    }
}
