using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 12;
    public int totalCollected = 0;
    private int currentSlots = 0;
    public SpriteRenderer ESprite;
    public TextMeshProUGUI trashtext;
    public GameObject ogcoral; 
    public GameObject coral1;
    public GameObject coral2;
    public GameObject coral3;

    public GameObject wall1;
    public GameObject wall2;
    



    public void Start()
    {
        trashtext.text = "0/" + maxSlots;
    }
    public bool TryAddTrash(int trashSize)
    {
        if (currentSlots + trashSize <= maxSlots)
        {
           
            currentSlots += trashSize;
            trashtext.text = currentSlots + "/" + maxSlots;
            return true;
        }
        else
        {
            return false; //full inventory
        }
    }

    public void ThrowOutTrash ()
    {
        totalCollected += currentSlots;
        currentSlots = 0;
        trashtext.text = currentSlots + "/" + maxSlots;
        if (totalCollected >= 3)
        {
            coral1.SetActive(true);
            wall1.SetActive(false);
            ogcoral.SetActive(false);
        }
        if (totalCollected >= 6)
        {
            coral2.SetActive(true);
            wall2.SetActive(false);
        }
        if (totalCollected >= 9)
        {
            coral3.SetActive(true);
        }
    }

    public void ChangeSprite(bool spritestate)
    { 
            ESprite.enabled = spritestate;
   }


    // Update is called once per frame
    void Update()
    {
        
    }
}
