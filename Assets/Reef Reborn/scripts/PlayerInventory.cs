using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 7;
    private int currentSlots = 0;

    public bool TryAddTrash(int trashSize)
    {
        if (currentSlots + trashSize <= maxSlots)
        {
            currentSlots += trashSize;
            return true;
        }
        else
        {
            return false; //full inventory
        }
    }


            // Start is called before the first frame update
            void Start()
            {

            }

    // Update is called once per frame
    void Update()
    {
        
    }
}
